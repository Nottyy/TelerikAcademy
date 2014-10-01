//Write a program that parses an URL address given in the format:

//        and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//        [protocol] = "http"
//        [server] = "www.devbg.org"
//        [resource] = "/forum/index.php"

using System;

class UrlParser
{
    static void Main()
    {
        Uri uri = new Uri("http://www.devbg.org/forum/index.php");

        Console.WriteLine("[protocol] = \"{0}\"", uri.Scheme);
        Console.WriteLine("[server] = \"{0}\"", uri.Host);
        Console.WriteLine("[resource] = \"{0}\"", uri.AbsolutePath);
    }
}

