import { createGlobalStyle } from "styled-components";

const globalStyles = createGlobalStyle `
    *{
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: 'Roboto', sans-serif;
        font-weight: 400;
    }

    body{
        background-color: rgb(51, 51, 51);
        color: white;
    }

    button{
        background-color: rgb(254, 123, 29);
        border: none;
        border-radius: 8px;
        color: black;
        max-width: 220px ;
        padding: 10px 5px;
        text-transform: uppercase;
        font-weight: 700;
        font-size: 1em;
        cursor: pointer;
        transition: all linear .4s;
    }
`

export default globalStyles;