import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';

@Component({
  selector: 'app-movie-theaters-boards',
  templateUrl: './movie-theaters-boards.component.html',
  styleUrls: ['./movie-theaters-boards.component.css'],
})
export class MovieTheatersBoardsComponent implements OnInit {
  theaters: any[] = [];

  constructor(public backend: BackendService, private router: Router) {}

  ngOnInit(): void {
    this.backend.get_request('Admin/Sucursales', null).subscribe((result) => {
      for (let i = 0; i < result.length; i++) {
        this.theaters.push(result[i]);
      }
    });
  }

  openTheatherBillBoard(theater: any) {
    //localStorage.setItem("theater",theater.name);
    this.router.navigate(['pages/billboard'], {
      queryParams: { theater: theater.name },
    });
  }
}
