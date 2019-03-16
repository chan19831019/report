import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportElevenComponent } from './report-eleven.component';

describe('ReportElevenComponent', () => {
  let component: ReportElevenComponent;
  let fixture: ComponentFixture<ReportElevenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportElevenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportElevenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
