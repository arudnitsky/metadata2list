using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace metadata2list
{
   internal class BookInfo
   {
      public string Title { get; set; }
      public List<string> Authors { get; set; }
   }

   internal class Program
   {
      private static int Main( string[] args )
      {
         if ( args.Count() != 1 )
         {
            Console.WriteLine( "usage: metadata2list path\\to\\metadata.calibre" );
            return  1;
         }

         var bookList = ReadBookList( args[0] );
         foreach ( var book in bookList.Reverse() )
         {
            Console.WriteLine( $"{book.Authors[0]}, {book.Title}" );
         }

         return 0;
      }

      private static IEnumerable<BookInfo> ReadBookList( string metadataFilename )
      {
         return  JsonConvert.DeserializeObject<List<BookInfo>>(File.ReadAllText(metadataFilename) );
      }
   }
   
   //internal static class BookJson
   //{
   //   public static string GetBookList()
   //   {
   //      return @"
   //   [
   //    {
   //       ""title"": ""Lawyers vs. Demons: And other odd short stories"", 
   //         ""authors"": [
   //         ""Scott Baron""
   //         ]
   //      }, 
   //        {
   //          ""title"": ""Darc Murders Collection_10-21-2013"", 
   //          ""authors"": [
   //            ""Carolyn McCray"",
   //            ""Ben Hopkin""
   //          ] 
   //        }, 
   //        {
   //          ""title"": ""The Twenty-four Hour Mind  The Role of Sleep and Dreaming in Our Emotional Lives B0058RTLX2 sample"", 
   //          ""authors"": [
   //            ""Unknown""
   //          ]
   //        }
   //      ]
   //      ";
   //   }
   //}

}
