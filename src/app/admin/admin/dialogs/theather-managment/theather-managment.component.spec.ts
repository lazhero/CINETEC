import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TheatherManagmentComponent } from './theather-managment.component';

describe('TheatherManagmentComponent', () => {
  let component: TheatherManagmentComponent;
  let fixture: ComponentFixture<TheatherManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TheatherManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheatherManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
