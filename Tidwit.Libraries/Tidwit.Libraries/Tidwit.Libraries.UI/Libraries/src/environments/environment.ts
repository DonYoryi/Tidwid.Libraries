// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  urlHost:'https://localhost:44383/',
  firebaseConfig : {
    apiKey: "AIzaSyD-irwuvHSQml0m_tBpaS00umfj_pjFKsM",
    authDomain: "tidwit-library.firebaseapp.com",
    projectId: "tidwit-library",
    storageBucket: "tidwit-library.appspot.com",
    messagingSenderId: "814335565059",
    appId: "1:814335565059:web:f91d8b61809b582a0edd36"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
