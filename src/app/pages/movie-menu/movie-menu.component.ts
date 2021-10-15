import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BackendService } from 'src/app/services/backend-service.service';
import { movieService } from 'src/app/services/movieService';
import { SwalService } from 'src/app/services/swalService';
import { DomSanitizer } from '@angular/platform-browser';
import { MatDialog } from '@angular/material/dialog';
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
    private sanitizer: DomSanitizer,
    public dialog: MatDialog
  ) {}

  chairs: any[] = [];
  projections: any[] = [];
  scrollableItemSize = 100;

  childCount: number = 0;
  adultCount: number = 0;
  olderCount: number = 0;

  currentProjection: any;
  selectedChairs: any[] = [];

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
    const user = JSON.parse(localStorage.getItem('user') as string);

    const urlParams = new URLSearchParams(window.location.search);
    //Obtiene la pelicula del localStorage
    this.movie = this.movieService.getCurrentMovie();
    const data = {
      Cinema_name: urlParams.get('theater'),
      Movie_name: this.movie.originalName,
    };

    this.backend.get_request('Client/Projection', data).subscribe((value) => {
      value.forEach(
        (projection: {
          roomNumber: number;
          initialTime: string;
          id: number;
          rows: number;
          columns: number;
        }) => {
          this.projections.push({
            room: 'S' + projection.roomNumber,
            hour: projection.initialTime,
            projectionId: projection.id,
            rows: projection.rows,
            columns: projection.columns,
          });
        }
      );
    });
  }

  validate() {
    if (
      this.childCount + this.adultCount + this.olderCount !=
      this.selectedChairs.length
    ) {
      this.swal.showError(
        'Error',
        'Por favor seleccione la misma cantidad de personas que de asientos '
      );
      return false;
    }
    if (!this.currentProjection) {
      this.swal.showError('Error', 'Por favor seleccione una sala ');
      return false;
    }

    if (this.selectedChairs.length < 1) {
      this.swal.showError('Error', 'Por favor uno o más asientos ');
      return false;
    }
    return true;
  }
  buyTicket(): void {
    if (!this.validate()) return;
    const user: string = JSON.parse(
      localStorage.getItem('user') as string
    ).username;
    let allChairNumber: number[] = [];
    let allChairName: string = '';

    this.selectedChairs.forEach((asiento) => {
      allChairNumber.push(asiento.seatNumber);
      allChairName += 'A' + asiento.seatNumber + ', ';
    });
    this.swal
      .htmloptionSwal(
        'Compra de tiquete',
        'A continuación se procederá a realizar la compra del tiquete <br><br>' +
          '<div class="text">Película: </div>' +
          this.movie.name +
          '<div class="text">Sala: </div>' +
          this.currentProjection.room +
          '<br><div class="text">Asientos: </div> ' +
          allChairName +
          '<br><div class="text">Usuario: </div>' +
          user +
          `
          <br>
          <div style="display:flex;gap:10px; flex-direction:row; align-items:center; align-items: center;justify-content:center">
          
            <div style="display:flex ;flex-direction:column">
              <div class="text">Niños</div>
              <div class="text">${this.childCount}</div>
            </div>

            <div style="display:flex ;flex-direction:column">
                <div class="text">Adultos</div>
                <div class="text">${this.adultCount}</div>
                
            </div>

            <div style="display:flex ;flex-direction:column">
                <div class="text">Adulto mayor</div>
                <div class="text">${this.olderCount}</div>
            </div>

          </div>
          ` +
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

        const data = {
          seats: allChairNumber,
          proj_id: this.currentProjection.projectionId,
          client_username: user,
          adult_tickets: this.adultCount,
          kid_tickets: this.childCount,
          elder_tickets: this.olderCount,
        };
        console.log(data);

        if (result.isConfirmed) {
          this.backend
            .put_request('Client/Seats', data)
            .subscribe((invoiceId) => {
              console.log(invoiceId);

              this.backend
                .get_request('Invoice', { Invoice_id: invoiceId })
                .subscribe((file) => {
                  console.log(file);

                  const linkSource =
                    'data:application/pdf;base64,' + file.fileContents;
                  const downloadLink = document.createElement('a');
                  const fileName = 'factura.pdf';

                  downloadLink.href = linkSource;
                  downloadLink.download = fileName;
                  downloadLink.click();

                  this.swal.showSuccess(
                    'Tiquete comprado',
                    'Descargando tu tiquete y tu factura,  ¡Nos vemos!'
                  );
                });
            });
        }
      });
  }

  /**
   * Projections
   */
  unselectAllProjections() {
    this.childCount = 0;
    this.adultCount = 0;
    this.olderCount = 0;
    this.projections.forEach((projection) => {
      projection.selected = false;
    });
    this.currentProjection = null;
    this.unselectAllChairs();
  }

  selectProjection(projection: any) {
    console.log(projection);

    this.unselectAllProjections();
    projection.selected = true;
    this.currentProjection = projection;

    this.backend
      .get_request('Client/Seats', {
        projection_id: this.currentProjection.projectionId,
      })
      .subscribe((asientos) => {
        asientos = asientos.sort((n1: any, n2: any) => {
          if (n1.seatNumber > n2.seatNumber) {
            return 1;
          }

          if (n1.seatNumber < n2.seatNumber) {
            return -1;
          }
        });

        let counter = 0;
        for (let y = 0; y < this.currentProjection.rows; y++) {
          let newRow = [];
          for (let x = 0; x < this.currentProjection.columns; x++) {
            newRow.push(asientos[counter]);
            counter++;
          }
          this.chairs.push(newRow);
        }
      });
  }

  selectChair(chair: any) {
    chair.selected = true;
    this.selectedChairs.push(chair);
  }
  /**
   * Unselect all chairs
   */
  unselectAllChairs() {
    this.selectedChairs = [];
  }
  unselectChair(chair: any) {
    for (let i = 0; i < this.selectedChairs.length; i++) {
      if (this.selectedChairs[i].seatNumber === chair.seatNumber) {
        this.selectedChairs.splice(i, 1);
      }
    }
  }

  isSelect(chair: any) {
    for (let i = 0; i < this.selectedChairs.length; i++) {
      if (this.selectedChairs[i].seatNumber === chair.seatNumber) {
        return true;
      }
    }
    return false;
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

  fixImage(image: any) {
    if (!image || !image.value) return;
    const fiximage = this.sanitizer.bypassSecurityTrustResourceUrl(
      `data:image/png;base64, ${image.value.fileContents}`
    );
    return fiximage;
  }
}
