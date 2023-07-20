using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.QueryConstants
{
    public class GraphqlQueries
    {
        public const string ViewBookDetails = @"
            query {
                Books {
                Id
                BookName
                Book_Author {
                Name
                Email}}
                }";

        public const string InsertBook = @"
                                         mutation AddBook($bookName: String!, $authorName: String!, $authorEmail: String!) {
                                         insert_Books(objects: { BookName: $bookName, Book_Author: { data: { Email: $authorEmail, Name: $authorName } } }) {
                                         affected_rows
                                         }
                                         }";

        public const string UpdateBook = @"
                                         mutation UpdateBook($id: Int!, $bookName: String!) {
                                         update_Books(where: { Id: { _eq: $id } }, _set: { BookName: $bookName }) {
                                         affected_rows
                                         }
                                         }";

        public const string DeleteBook = @"
                                         mutation MyMutation($id: Int!) {
                                         delete_Books(where: {Id: {_eq: $id}}) {
                                         affected_rows
                                         }
                                         }";
    }
}
