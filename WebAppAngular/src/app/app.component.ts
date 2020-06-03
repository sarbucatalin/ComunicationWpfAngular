import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'WebAppAngular';
  messageFromRabbit: string = '';
  private hubConnection: signalR.HubConnection;

  ngOnInit(): void {
    this.buildConnection();
    this.startConnection();
  }

  public buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/signalRHub')
      .build();
  };

  public startConnection = () => {
    this.hubConnection
      .start()
      .then(() => {
        console.log('connection started!!!!');
        this.hubConnection.on('SignalRMessageReceived', (data: string) => {
          this.messageFromRabbit = data;
        });
      })
      .catch((err) => console.log(err));
  };
}
