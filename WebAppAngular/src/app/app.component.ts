import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'WebAppAngular';
  messageFromRabbit: string = '';
  private hubConnection: signalR.HubConnection;

  constructor(private http: HttpClient) {}

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
          this.messageFromRabbit += data;
        });
      })
      .catch((err) => console.log(err));
  };

  sendMessage(message: string): void {
    const msg = { Value: message };
    //console.log(msg);
    this.http
      .post('https://localhost:5001/api/message', msg, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .subscribe({
        next: () => console.log('success'),
        error: (error) => console.error('There was an error!', error),
      });
  }
}
