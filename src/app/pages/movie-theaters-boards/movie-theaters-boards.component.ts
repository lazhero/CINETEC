import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-theaters-boards',
  templateUrl: './movie-theaters-boards.component.html',
  styleUrls: ['./movie-theaters-boards.component.css']
})
export class MovieTheatersBoardsComponent implements OnInit {

  cities: any[] = [];
  
  constructor() { }

  ngOnInit(): void {

    this.cities.push({name:'CityMall'});
    this.cities.push({name:'Paseo Metropoli'});
    this.cities.push({name:'Playground Oxigeno'});


  }

}
