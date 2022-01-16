import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor(public authService: AuthService) { }

  ngOnInit(): void {
    this.authService.isLoggedIn.subscribe(next => {
      this.isLoggedIn = next;
    })
  }
}
