import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';
import { movieService } from 'src/app/services/movieService';
import { SwalService } from 'src/app/services/swalService';
@Component({
  selector: 'app-billboard',
  templateUrl: './billboard.component.html',
  styleUrls: ['./billboard.component.css'],
})
export class BillboardComponent implements OnInit {
  movies: any[] = [];

  constructor(
    public router: Router,
    public backend: BackendService,
    private swal: SwalService,
    public mService: movieService
  ) {}

  ngOnInit(): void {}
  movieSelected(movie: any): void {
    this.mService.openMovie(movie);
    this.router.navigateByUrl('pages/movieMenu');
  }
}
