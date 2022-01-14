import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class AuthService {
	url:string = 'https://localhost:7284/api/auth/';
	isLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

	constructor(private http: HttpClient) {}

	login(model: any) {
		return this.http.post<any>(this.url + 'login', model).pipe(
			map((response: any) => {
				const user = response;
				if (user) {
					localStorage.setItem('token', user.token);
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
		return !!token;
	}

	logOut() {
		localStorage.removeItem('token');
		this.isLoggedIn.next(false);
		console.log('logged out');
	}
}
