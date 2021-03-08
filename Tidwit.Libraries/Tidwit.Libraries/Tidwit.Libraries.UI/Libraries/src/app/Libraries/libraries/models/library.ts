export class Library {
    name:string;
    description:string;
    publishDate:Date;
    language:string;
    isPublic:boolean;
    parentLibrary:string;
    urlImage:string;
    id:number;
    filePath: string;

    constructor(){
      this.name= "";
      this.description= "";
      this.language= "";
      this.isPublic = false;
      this.parentLibrary ="";
      this.id=0;
    }
  }