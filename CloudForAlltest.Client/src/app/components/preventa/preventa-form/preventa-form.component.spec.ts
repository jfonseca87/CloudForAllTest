import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreventaFormComponent } from './preventa-form.component';

describe('PreventaFormComponent', () => {
  let component: PreventaFormComponent;
  let fixture: ComponentFixture<PreventaFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreventaFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreventaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
