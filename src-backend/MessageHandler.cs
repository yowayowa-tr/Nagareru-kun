using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Graph;

namespace src_backend
{
    public class MessageHandler
    {
        private Uri uri;
        private string teamId;
        private string channelId;
        private string messageId;
        private GraphServiceClient client;
        private DateTimeOffset lastDate;

        //for demo
        public Replies rep = new Replies();


        private void SetParameter(GraphServiceClient client,  string url)
        {
            this.client = client;
            uri = new Uri(url);
            teamId = HttpUtility.ParseQueryString(uri.Query).Get("groupId");
            channelId = url.Split('/')[5];
            messageId = HttpUtility.ParseQueryString(uri.Query).Get("parentMessageId");
        }


        //public async Task<List<string>> GetMessage(GraphServiceClient client, string url)

        //for demo
        public List<string> GetMessage(GraphServiceClient client, string url)
        {
            var messages = new List<string>();

            try
            {
                //var replies = await client.Teams[teamId].Channels[channelId].Messages[messageId].Replies
                //        .Request()
                //        .GetAsync();

                //for demo
                var replies = rep.contents;

                if (uri == null || this.client == null || uri.AbsoluteUri != url || this.client != client)
                {
                    SetParameter(client, url);
                    lastDate = new DateTimeOffset();

                    foreach (ChatMessage reply in replies)
                    {
                        if (lastDate < reply.CreatedDateTime)
                        {
                            lastDate = reply.CreatedDateTime.Value;
                        }
                    }
                }
                else
                {
                    foreach (ChatMessage reply in replies)
                    {
                        if (lastDate < reply.CreatedDateTime)
                        {
                            messages.Add(reply.Body.Content);
                            lastDate = reply.CreatedDateTime.Value;
                        }
                    }
                }
            }
            catch (ServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UriFormatException ex)
            {
                Console.WriteLine(ex.Message);
                
            }

            return messages;
        }

        public async Task SetMessage(GraphServiceClient client, string url, string message)
        {
            try
            {
                SetParameter(client, url);
                var chatMessage = new ChatMessage
                {
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Html,
                        Content = message
                    }
                };

                await client.Teams[teamId].Channels[channelId].Messages[messageId].Replies
                    .Request()
                    .AddAsync(chatMessage);

                //for demo
                rep.AddReply(DateTimeOffset.Now, message);
            }
            catch (ServiceException ex)
            {
                Console.WriteLine(ex.StatusCode);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Null Reference Exception happened.");
                Console.WriteLine(ex.Message);
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Uri Format Exception happened.");
            }
        }
    }
}
