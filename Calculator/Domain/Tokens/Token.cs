namespace Domain.Tokens
{
    public enum TokenType
    {
        Number,
        Plus,
        Minus
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
    }

    public record NumberToken(int Value) : Token(TokenType.Number);
    public record PlusToken() : Token(TokenType.Plus);
    public record MinusToken() : Token(TokenType.Minus);
}