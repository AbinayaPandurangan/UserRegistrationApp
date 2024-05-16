import { Dispatch, SetStateAction } from "react";
import { ResponseUserData } from "../models/FormDataModal";

interface Props {
  regUserInfo: ResponseUserData | null | undefined;
  setUserLogin: Dispatch<SetStateAction<boolean>>;
}

function ConfirmationPage(props: Props) {
  return (
    <>
      <div className="container">
        <h1>Confirmation</h1>
        <p className="cartitle">
          User is successfully registered with the following details:
        </p>
        <p className="cartitle">
          User Name : {props.regUserInfo?.data.userName}
        </p>
        <p className="cartitle">
          Date Of Birth : {props.regUserInfo?.data.dob.substring(0, 10)}
        </p>
        <p className="cartitle">Email : {props.regUserInfo?.data.email}</p>

        <p className="cartitle">
          Phone No. : {props.regUserInfo?.data.phoneNo}
        </p>
        <p className="cartitle">
          Gender : {props.regUserInfo?.data.genderName}
        </p>
        <button
          className="button primary buttontxt"
          onClick={() => props.setUserLogin(false)}
        >
          Register Another User
        </button>
      </div>
    </>
  );
}

export default ConfirmationPage;
