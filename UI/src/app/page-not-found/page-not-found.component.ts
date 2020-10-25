import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.scss']
})
export class PageNotFoundComponent implements OnInit {
  public RequestedUrl : string = '';
  constructor(private router : ActivatedRoute) { }

  ngOnInit(): void {
    this.RequestedUrl = this.router.snapshot.url.join('');
  }

}
