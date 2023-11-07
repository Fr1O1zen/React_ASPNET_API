import * as signalR from '@microsoft/signalr';

const signalRConnection = new signalR.HubConnectionBuilder()
  .withUrl('/productHub')
  .build();

signalRConnection.start().catch((error) => console.error(error));

signalRConnection.on('ReceiveProductUpdate', (productId) => {
  // Handle the product update, e.g., by fetching the updated data.
  // You can call a function to refresh the product data here.
});

export default signalRConnection;