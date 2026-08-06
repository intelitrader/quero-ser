import { StyledButton } from "./style";

export const Button = ({children, onClick}) => {
  return (
    <StyledButton
    onClick={onClick}
    >
      {children}
    </StyledButton>
  );
};