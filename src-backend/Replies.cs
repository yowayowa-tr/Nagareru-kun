using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Graph;

namespace src_backend
{
    public class Replies
    {
        public List<ChatMessage> contents = new List<ChatMessage>();

        public void AddReply(DateTimeOffset time, string message)
        {
            contents.Add(
                new ChatMessage
                {
                    CreatedDateTime = time,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Html,
                        Content = message
                    }
                }
            );
        }

        public void AddSample()
        {
            DateTimeOffset time = new DateTimeOffset(0001, 10, 11, 00, 00, 00, TimeSpan.Zero);
            string message = "content1";

            AddReply(time, message);

            time = DateTimeOffset.Now;
            message = "content2";

            AddReply(time, message);
        }

        public Replies()
        {
            AddSample();
        }
    }
}