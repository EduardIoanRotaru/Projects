import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class AuthService {
	url: string = 'https://localhost:7284/api/auth/';
	isLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(this.loggedIn());
	decodedToken: any;

	constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {}

	login(model: any) {
		return this.http.post<any>(this.url + 'login', model).pipe(
			map((response: any) => {
				const user = response;
				if (user) {
					localStorage.setItem('token', user.token);
					this.decodedToken = this.jwtHelper.decodeToken(user.name);
					this.isLoggedIn.next(true);
				}
			})
		);
	}

	register(model: any) {
		return this.http.post<any>(this.url + 'register', model);
	}

	loggedIn() {
		const token = localStorage.getItem('token');
		return token !== null ? this.jwtHelper.isTokenExpired(token) : false;
	}

	logOut() {
		localStorage.removeItem('token');
		this.decodedToken = undefined;
		this.isLoggedIn.next(false);
	}
}
