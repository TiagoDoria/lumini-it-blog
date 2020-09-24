/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Publicar_postComponent } from './publicar_post.component';

describe('Publicar_postComponent', () => {
  let component: Publicar_postComponent;
  let fixture: ComponentFixture<Publicar_postComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Publicar_postComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Publicar_postComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
