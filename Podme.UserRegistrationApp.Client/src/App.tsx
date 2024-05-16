import { useState } from "react";
import "./App.css";
import ConfirmationPage from "./components/ConfirmationComponent";
import LoadingComponent from "./components/LoadingComponent";
import RegistrationPage from "./components/RegistrationFormComponent";
import {
  UserRegistrationFormData,
  ApiResponse,
  ResponseUserData,
} from "./models/FormDataModal";

function App() {
  const [loading, setLoading] = useState(false);
  const [regUserInfo, setRegUserInfo] = useState<ResponseUserData | null>();
  const [userLoginConfirmation, setUserLoginConfirmationPage] = useState(false);

  function submitForm(formData: UserRegistrationFormData) {
    setLoading(true);
    postFetch(
      "https://localhost:7039/api/UserRegistration/RegisterUser",
      formData
    )
      .then((response: any) => response.json())
      .then((data: ApiResponse) => {
        if (data.isSuccess == true) {
          getSavedUserInfo(data);
        } else {
          alert(data.data);
          setLoading(false);
        }
      })
      .catch((error: any) => {
        console.error(error);
        alert(error);
        setLoading(false);
      });
  }

  function getSavedUserInfo(data: ApiResponse) {
    postFetch(
      "https://localhost:7039/api/UserRegistration/GetRegisteredUser",
      data.data
    )
      .then((response: any) => response.json())
      .then((data: ResponseUserData) => {
        setRegUserInfo(data);
        setUserLoginConfirmationPage(true);
        setLoading(false);
      })
      .catch((error: any) => {
        console.error(error);
        alert(error);
        setLoading(false);
        setRegUserInfo(null);
      });
  }

  function postFetch(url: string, data: any) {
    var apiRequest: any = fetch(url, {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
    return apiRequest;
  }

  if (loading) return <LoadingComponent />;
  if (userLoginConfirmation) return (
      <ConfirmationPage
        regUserInfo={regUserInfo}
        setUserLogin={setUserLoginConfirmationPage}
      />
    );

  return (
    <>
      <RegistrationPage submitForm={submitForm} />
    </>
  );
}

export default App;
