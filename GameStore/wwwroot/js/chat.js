"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// receive message
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user.bold() + ": " + msg;
    var li = document.createElement("li");
    li.classList.add("list-group-item");
    li.innerHTML = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

// catch errors
connection.start().catch((err) => console.error(err.toString()));

// send message
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    document.getElementById("messageInput").value = null;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});