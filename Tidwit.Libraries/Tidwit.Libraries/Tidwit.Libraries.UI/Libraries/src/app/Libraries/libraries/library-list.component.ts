import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Library } from './models/library'
import { LibraryService } from './shared/library.service';

@Component({
  selector: 'app-library-list',
  templateUrl: './library-list.component.html',
  styleUrls: ['./library-list.component.scss']
})
export class LibraryListComponent implements AfterViewInit,OnInit  {

  displayedColumns: string[] = ['id','name', 'description', 'publishDate', 'language'];
  dataSource = new MatTableDataSource<Library>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private libraryService : LibraryService,
    private router: Router,){

  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit(){
  this.getAll()
  }
  getAll() {
    this.libraryService.getAllLibraries().then(dataResult=>{
      this.dataSource.data = dataResult;
    });
  }
  navigationCrear(){
    this.router.navigate([`/create`]);
  }
  navigationEdit(idLibrary:number){
    this.router.navigate([`/edit/${idLibrary}`]);
  }
  deleteLibrary(idLibrary:number){
    this.libraryService.DeleteLibrary(idLibrary).then(x=>{
      this.getAll();
    })
  }
}

