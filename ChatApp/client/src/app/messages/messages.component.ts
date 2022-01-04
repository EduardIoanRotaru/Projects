import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
  messages: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<any>('https://localhost:5001/messages').subscribe(m => {
      this.messages = m;
    })
  }

}
