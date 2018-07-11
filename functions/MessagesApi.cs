using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;

namespace Serverless
{
    public static class MessagesApi
    {
        [FunctionName("addmessage")]
        public static IActionResult Add(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route="messages/add")]
            ChatMessage chatMessage,
            [CosmosDB("chatsystem", "messages", Id = "id", ConnectionStringSetting = "CosmosDB")]
            out dynamic document,
            TraceWriter log)
        {
            document = new
            {
                id = Guid.NewGuid(),
                user = chatMessage.User,
                message = chatMessage.Message
            };

            return new OkResult();
        }

        [FunctionName("messageslist")]
        public static IActionResult List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route="messages/list")]
            HttpRequest reuqest,
            [CosmosDB("chatsystem", "messages", ConnectionStringSetting = "CosmosDB")]
            IEnumerable<ChatMessage> chatMessages,
            TraceWriter log)
        {
            return new OkObjectResult(chatMessages);
        }
    }
}