using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Library_Management.Interfaces;
using Library_Management.Models;
using Library_Management.QueryConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Services
{
    public class LibraryService : ILibraryService
    {



        public async Task <List<BookDetails>> GetBookDetails()
        {
            var bookDetails = new List<BookDetails>();
            var graphQLHttpClient = new GraphQLHttpClient("https://star-poodle-97.hasura.app/v1/graphql", new NewtonsoftJsonSerializer());

            graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("x-hasura-admin-secret", "4yjP4yhYD4kiWMVOJvD6fuB74cboiPG9A298LXZK3MopEVkwghke7WSzQVP9Mt4O");
            var graphQLRequest = new GraphQLRequest
            {
                Query = GraphqlQueries.ViewBookDetails
            };

            var graphQLResponse = await graphQLHttpClient.SendQueryAsync<dynamic>(graphQLRequest);
            var books = graphQLResponse.Data.Books;
            foreach (var book in books)
            {
                bookDetails.Add(new BookDetails
                {
                    Id = book.Id,
                    BookName = book.BookName.ToString(),
                    Author = book.Book_Author.Name.ToString(),
                    Email = book.Book_Author.Email.ToString()
                });
            }
            return bookDetails;
        }

        public async Task InsertBook(InsertBookDetails bookDetails)
        {
            var graphQLHttpClient = new GraphQLHttpClient("https://star-poodle-97.hasura.app/v1/graphql", new NewtonsoftJsonSerializer());

            // Set the x-hasura-admin-secret header
            graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("x-hasura-admin-secret", "4yjP4yhYD4kiWMVOJvD6fuB74cboiPG9A298LXZK3MopEVkwghke7WSzQVP9Mt4O");

            var graphQLRequest = new GraphQLRequest
            {
                Query = GraphqlQueries.InsertBook,
                Variables = new
                {
                    bookName = bookDetails.BookName,
                    authorName = bookDetails.Author,
                    authorEmail = bookDetails.Email
                }
            };

           await graphQLHttpClient.SendMutationAsync<dynamic>(graphQLRequest);
        }

        public async Task UpdateBook(string bookName, int userId)
        {
            var graphQLHttpClient = new GraphQLHttpClient("https://star-poodle-97.hasura.app/v1/graphql", new NewtonsoftJsonSerializer());

            // Set the x-hasura-admin-secret header
            graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("x-hasura-admin-secret", "4yjP4yhYD4kiWMVOJvD6fuB74cboiPG9A298LXZK3MopEVkwghke7WSzQVP9Mt4O");

            var graphQLRequest = new GraphQLRequest
            {
                Query = GraphqlQueries.UpdateBook,
                Variables = new
                {
                    id = userId,
                    bookName = bookName
                }
            };

            await graphQLHttpClient.SendMutationAsync<dynamic>(graphQLRequest);
        }


        public async Task DeleteBook(int id)
        {
            var graphQLHttpClient = new GraphQLHttpClient("https://star-poodle-97.hasura.app/v1/graphql", new NewtonsoftJsonSerializer());

            graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("x-hasura-admin-secret", "4yjP4yhYD4kiWMVOJvD6fuB74cboiPG9A298LXZK3MopEVkwghke7WSzQVP9Mt4O");

            var graphQLRequest = new GraphQLRequest
            {
                Query = GraphqlQueries.DeleteBook,
                Variables = new { id }
            };

            await graphQLHttpClient.SendMutationAsync<dynamic>(graphQLRequest);
        }
    }
}
