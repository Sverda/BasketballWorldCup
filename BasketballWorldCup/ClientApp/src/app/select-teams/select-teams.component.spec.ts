import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectTeamsComponent } from './select-teams.component';

describe('SelectTeamsComponent', () => {
  let component: SelectTeamsComponent;
  let fixture: ComponentFixture<SelectTeamsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectTeamsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectTeamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
