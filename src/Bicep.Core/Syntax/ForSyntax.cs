// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Bicep.Core.Parsing;

namespace Bicep.Core.Syntax
{
    public class ForSyntax : SyntaxBase
    {
        public ForSyntax(
            Token openSquare,
            Token forKeyword,
            IdentifierSyntax identifier,
            Token inKeyword,
            SyntaxBase expression,
            Token colon,
            SyntaxBase body,
            Token closeSquare)
        {
            AssertTokenType(openSquare, nameof(openSquare), TokenType.LeftSquare);
            AssertKeyword(forKeyword, nameof(forKeyword), LanguageConstants.ForKeyword);
            AssertKeyword(inKeyword, nameof(inKeyword), LanguageConstants.InKeyword);
            AssertTokenType(colon, nameof(colon), TokenType.Colon);
            AssertTokenType(closeSquare, nameof(closeSquare), TokenType.RightSquare);
            
            this.OpenSquare = openSquare;
            this.ForKeyword = forKeyword;
            this.Identifier = identifier;
            this.InKeyword = inKeyword;
            this.Expression = expression;
            this.Colon = colon;
            this.Body = body;
            this.CloseSquare = closeSquare;
        }

        public Token OpenSquare { get; }

        public Token ForKeyword { get; }

        public IdentifierSyntax Identifier { get; }

        public Token InKeyword { get; }

        public SyntaxBase Expression { get; }

        public Token Colon { get; }

        public SyntaxBase Body { get; }

        public Token CloseSquare { get; }

        public override void Accept(ISyntaxVisitor visitor) => visitor.VisitForSyntax(this);

        public override TextSpan Span => TextSpan.Between(this.OpenSquare, this.CloseSquare);
    }
}