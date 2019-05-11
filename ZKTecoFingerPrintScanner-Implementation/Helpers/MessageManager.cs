namespace ZKTecoFingerPrintScanner_Implementation.Helpers
{
    public class MessageManager
    {
        public const string msg_FP_InitComplete = "Initialization completed";

        public const string msg_FP_NotConnected = "No device connected !!";

        public const string msg_FP_PressForVerification = "Please press your finger for verification !";

        public const string msg_FP_PressForIdentification = "Please press your finger for identification !";

        public const string msg_FP_CurrentFingerAlreadyRegistered = "This finger is already registerd with id ";

        public const string msg_FP_EnrollSuccessfull = "You have successfully enrolled the user.";

        public const string msg_FP_FailedToAddTemplate = "Failed to add the users template";

        public const string msg_FP_UnableToEnrollCurrentUser = "Unable to enroll the current user. Error Code: ";

        public const string msg_FP_MatchSuccess = "Match Successfull. Score: ";

        public const string msg_FP_MatchFailed = "Match Failed. Score: ";

        public const string msg_FP_IdentificationSuccess = "Identification Failed. Score: ";

        public const string msg_FP_IdentificationFailed = "Identification Failed. Score: ";

        public const string msg_FP_UnidentifiedFingerPrint = "Un-identified fingerprint. Please enroll to register.";

        public const string msg_FP_Disconnected = "You have disconnected from the device. ";

        public const string msg_FP_FailedToReleaseResources = "Failed to release the resources !!";

        public const string msg_FP_UnableToDeleteFingerPrint = "Unable to delete the fingerprint with id ";

    }

}
