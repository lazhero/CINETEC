import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css'],
})
export class PagesComponent implements OnInit {
  constructor(private router: Router) {}
  currentUsername: string = '';
  ngOnInit(): void {
    const user: any = JSON.parse(localStorage.getItem('user') as string);
    this.currentUsername = user.firstName + ' ' + user.lastName;
  }
  logout() {
    localStorage.removeItem('user');
    this.router.navigateByUrl('auth/login');
  }
  home() {
    this.router.navigateByUrl('pages/movieTheatreSelection');
  }
}
