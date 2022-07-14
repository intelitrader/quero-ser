import { createGlobalStyle } from "styled-components";

const globalStyles = createGlobalStyle `
    *{
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: Arial, sans-serif;
    }

    body{
        background-color: #0B0B3B;
        color: white;
    }

    button{
        background-color: #FAAC58;
        border: none;
        border-radius: 8px;
        color: #0B0B3B;
        max-width: 220px ;
        padding: 10px 5px;
        text-transform: uppercase;
        font-weight: bold;
        cursor: pointer;
        transition: all linear .4s;
    }
`

export default globalStyles;