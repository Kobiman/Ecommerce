import { Component, Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EcommerceHttpService{
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
     this.baseUrl = baseUrl;
  }

    private baseUrl: any;

    post(url: string, data: any) {
      return this.http.post(this.baseUrl + url, data);
    }

    deleteFile(url: string) {
      return this.http.put(this.baseUrl + url, null);
    }

    get(url: string) {
      return this.http.get(this.baseUrl + url);
    }

    postFile(url: string, files: File[]) {
      const formData: FormData = new FormData();
      for (const file of files) {
            formData.append(file.name, file);
      }

    return this.http.post(this.baseUrl + url, formData);
    }

}
