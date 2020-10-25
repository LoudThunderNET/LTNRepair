import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptionRegistryCardComponent } from './reception-registry-card.component';

describe('ReceptionRegistryCardComponent', () => {
  let component: ReceptionRegistryCardComponent;
  let fixture: ComponentFixture<ReceptionRegistryCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReceptionRegistryCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptionRegistryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
