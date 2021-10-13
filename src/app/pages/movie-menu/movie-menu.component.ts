import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BackendService } from 'src/app/services/backend-service.service';
import { movieService } from 'src/app/services/movieService';
import { SwalService } from 'src/app/services/swalService';
import { DomSanitizer } from '@angular/platform-browser';
@Component({
  selector: 'app-movie-menu',
  templateUrl: './movie-menu.component.html',
  styleUrls: ['./movie-menu.component.css'],
})
export class MovieMenuComponent implements OnInit {
  constructor(
    public snackmat: MatSnackBar,
    public backend: BackendService,
    private swal: SwalService,
    private movieService: movieService,
    private sanitizer: DomSanitizer
  ) {}
  chairs: any[] = [];
  projections: any[] = [];
  scrollableItemSize = 100;

  currentProjection: any;
  currentChair: any;

  movie: any;

  @ViewChild('panel', { read: ElementRef }) public panel: any;
  randomIntFromInterval(min: number, max: number) {
    // min and max included
    return Math.floor(Math.random() * (max - min + 1) + min);
  }
  getRandomBool() {
    var numb = this.randomIntFromInterval(0, 100);

    return numb % 2 === 0;
  }

  ngOnInit(): void {
    const urlParams = new URLSearchParams(window.location.search);

    const data = {
      Cinema_name: urlParams.get('theater'),
      Movie_name: urlParams.get('movie'),
    };
    //Obtiene la pelicula del localStorage
    this.movie = this.movieService.getCurrentMovie();
    //Asegura la imagen
    this.movie.image = this.sanitizer.bypassSecurityTrustResourceUrl(
      this.movie.image.changingThisBreaksApplicationSecurity
    );

    this.backend.get_request('Client/Projection', data).subscribe((value) => {
      value.forEach(
        (projection: { roomNumber: number; initialTime: string }) => {
          this.projections.push({
            room: 'S' + projection.roomNumber,
            hour: projection.initialTime,
          });
        }
      );
    });

    for (let i = 0; i < 50; i++) {
      const newChair = {
        state: this.getRandomBool(),
        number: 'A' + i,
        selected: false,
      };

      this.chairs.push(newChair);
    }
  }

  /**
   * It verifies the process of buying tickets and do the buy
   * @returns
   */
  buyTicket(): void {
    if (!this.currentProjection || !this.currentChair) {
      this.swal.showError(
        'Error',
        'Por favor seleccione una sala y un asiento válido'
      );
      return;
    }

    this.swal
      .htmloptionSwal(
        'Compra de tiquete',
        'A continuación se procederá a realizar la compra del tiquete <br><br> Sala:' +
          this.currentProjection.room +
          '<br>Asiento:' +
          this.currentChair.number +
          '<br><br> Por favor inserte su targeta de crédito para realizar la compra',
        'Cancelar',
        'Comprar',
        '',
        'text'
      )
      ?.then((result) => {
        if (String(result.value).length < 1) {
          this.swal.showError('Error', 'inserte una targeta de crédito válida');
          return;
        }

        if (result.isConfirmed) {
          this.swal.showSuccess(
            'Tiquete comprado',
            'Descargando tu tiquete y tu factura,  ¡Nos vemos!'
          );
        }
      });
  }
  /**
   * Unselect all chairs
   */
  unselectAllChairs() {
    this.chairs.forEach((chair) => {
      chair.selected = false;
    });
    this.currentChair = null;
  }
  /**
   * Projections
   */
  unselectAllProjections() {
    this.projections.forEach((projection) => {
      projection.selected = false;
    });
    this.currentProjection = null;
  }
  selectProjection(projection: any) {
    this.unselectAllProjections();
    projection.selected = true;
    this.currentProjection = projection;
  }

  selectChair(chair: any) {
    this.unselectAllChairs();
    chair.selected = true;
    this.currentChair = chair;
  }
  /**
   * moves the (itemScroll) projectionsScroll to the left
   */
  moveLeft(): void {
    this.panel.nativeElement.scrollTo({
      left: this.panel.nativeElement.scrollLeft - this.scrollableItemSize,
      behavior: 'smooth',
    });
  }

  /**
   * moves the (itemScroll) projectionsScroll to the Right
   */
  moveRight(): void {
    this.panel.nativeElement.scrollTo({
      left: this.panel.nativeElement.scrollLeft + this.scrollableItemSize,
      behavior: 'smooth',
    });
  }
}
