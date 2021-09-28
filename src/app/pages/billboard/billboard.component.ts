import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-billboard',
  templateUrl: './billboard.component.html',
  styleUrls: ['./billboard.component.css']
})
export class BillboardComponent implements OnInit {

  movies: any[] = [];

  constructor() { }

  ngOnInit(): void {
    
    this.movies.push({name:'Prueba1', image: 'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg'})
    this.movies.push({name:'Prueba1', image: 'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg'})
    this.movies.push({name:'Prueba1', image: 'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg'})
    this.movies.push({name:'Prueba1', image: 'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg'})
    this.movies.push({name:'Prueba1', image: 'https://es.web.img2.acsta.net/pictures/19/11/12/12/25/0815514.jpg'})

  }
  movieSelected(movieName: any): void {
    console.log("Seleccioné la película "+movieName);
    
  }
}
