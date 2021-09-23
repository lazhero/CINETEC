import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieTheatersBoardComponent } from './movie-theaters-board.component';

describe('MovieTheatersBoardComponent', () => {
  let component: MovieTheatersBoardComponent;
  let fixture: ComponentFixture<MovieTheatersBoardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieTheatersBoardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieTheatersBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
