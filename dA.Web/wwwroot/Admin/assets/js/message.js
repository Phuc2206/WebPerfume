"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").withAutomaticReconnect().build();

connection.on("ReceiveMessage", function (message) {
	Toast.success(message);
});

connection.start();

