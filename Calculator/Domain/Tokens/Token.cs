namespace Domain.Tokens
{
    public enum TokenType
    {
        Number,
        Plus,
        Minus,
        Multiplication,
        Division,
        LeftParenthesis,
        RightParenthesis
    }

    public abstract record Token
    {
        public TokenType TokenType { get; }

        protected Token(TokenType tokenType)
        {
            TokenType = tokenType;
        }

        public static Token Number(int value)
            => new NumberToken(value);

        public static Token Plus
            => new PlusToken();

        public static Token Minus
            => new MinusToken();

        public static Token Multiplication
            => new MultiplicationToken();

        public static Token Division
            => new DivisionToken();

        public static Token LeftParenthesis
            => new LeftParenthesisToken();

        public static Token RightParenthesis
            => new RightParenthesisToken();
    }

    public record NumberToken(int Value) : Token(TokenType.Number);
    public record PlusToken() : Token(TokenType.Plus);
    public record MinusToken() : Token(TokenType.Minus);
    public record MultiplicationToken() : Token(TokenType.Multiplication);
    public record DivisionToken() : Token(TokenType.Division);
    public record LeftParenthesisToken() : Token(TokenType.LeftParenthesis);
    public record RightParenthesisToken() : Token(TokenType.RightParenthesis);
}