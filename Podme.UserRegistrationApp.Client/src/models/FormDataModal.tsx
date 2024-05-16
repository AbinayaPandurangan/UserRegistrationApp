export interface UserRegistrationFormData {
    userName : string,
    dob : string,
    email : string,
    phoneNo : string,
    genderId : number
}

export interface ApiResponse {
   data:{
       id:number,
   },
   isSuccess: boolean
}

export interface ResponseUserData {
    data:{
        userName:string,
        email: string,
        phoneNo: string,
        genderName: string,
        dob: string,
        genderId: string
    },
    isSuccess: boolean
 }


