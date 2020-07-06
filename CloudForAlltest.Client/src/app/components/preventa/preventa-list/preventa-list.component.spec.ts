import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreventaListComponent } from './preventa-list.component';

describe('PreventaListComponent', () => {
  let component: PreventaListComponent;
  let fixture: ComponentFixture<PreventaListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreventaListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreventaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
