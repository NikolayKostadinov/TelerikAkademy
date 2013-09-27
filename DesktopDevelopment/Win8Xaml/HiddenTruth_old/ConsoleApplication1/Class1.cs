using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Blogger.v3;
using Google.Apis.Services;

namespace ConsoleApplication1
{
    static class Class1
    {
        static void Main(string[] args)
        {
            Google.Apis.Blogger.v3.BloggerService bs = new BloggerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCkyf5p4x_2tW-Bwmqt7Bbj-HhFIC_kXvw",
            });
            Google.Apis.Blogger.v3.BlogsResource br = new BlogsResource(bs);
            var res = br.GetByUrl("http://blogzaserioznihora.blogspot.com/").Execute();
            
            Google.Apis.Blogger.v3.PostsResource pr = new PostsResource(bs);
            var list = pr.List("7485604791378022116");
            list.FetchBodies = false;
            var result = list.Execute();

            
        }
    }
}
