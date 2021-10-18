import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectionsManagmentComponent } from './projections-managment.component';

describe('ProjectionsManagmentComponent', () => {
  let component: ProjectionsManagmentComponent;
  let fixture: ComponentFixture<ProjectionsManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectionsManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectionsManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
