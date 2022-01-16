import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  jwtHelperService =  new JwtHelperService();

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
      const token = localStorage.getItem('token');
      if(token) {
        console.log('I shouldnt be here');
        this.authService.isLoggedIn.next(true);
        this.authService.decodedToken = this.jwtHelperService.decodeToken(token);
      }
  }
}
