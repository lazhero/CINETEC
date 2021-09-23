import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieMenuComponent } from './movie-menu.component';

describe('MovieMenuComponent', () => {
  let component: MovieMenuComponent;
  let fixture: ComponentFixture<MovieMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
