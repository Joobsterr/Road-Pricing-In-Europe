import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    constructor(
        public router: Router,
    ) {
    }
    get isLoggedIn(): boolean {
        const authToken = localStorage.getItem('userID');
        if (authToken == null) {
            return false;
        }
        return true;
    }
}
