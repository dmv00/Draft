export class Response<T>{
   public data: T;
   public message: string;
   public errors: Array<string>

   constructor(data: T, message: string, errors: Array<string>) {
      this.data = data;
      this.message = message;
      this.errors = errors;
   }
}