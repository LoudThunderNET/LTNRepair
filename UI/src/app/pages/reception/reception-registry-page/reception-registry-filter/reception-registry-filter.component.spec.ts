import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptionRegistryFilterComponent } from './reception-registry-filter.component';

describe('ReceptionRegistryFilterComponent', () => {
  let component: ReceptionRegistryFilterComponent;
  let fixture: ComponentFixture<ReceptionRegistryFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReceptionRegistryFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptionRegistryFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
