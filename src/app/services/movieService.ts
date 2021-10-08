import { Injectable } from '@angular/core';

@Injectable()
export class movieService {
  openMovie(newMovie: any) {
    localStorage.setItem('cM', JSON.stringify(newMovie));
  }
  getCurrentMovie() {
    const value = localStorage.getItem('cM');
    if (value) return JSON.parse(value);
  }
}
