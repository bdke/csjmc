// Generated from c:/Users/User/source/repos/JMC/JMC.Parser/grammars/JMCParser.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class JMCParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		SIMPLE_ADDICTIVE=1, MULTIPACATION=2, ADDICTIVE=3, COMPARATOR=4, COMPARASION=5, 
		ASSIGN=6, ASSIGN_OPERATORS=7, ARROW=8, BLOCK_START=9, BLOCK_END=10, LIST_START=11, 
		LIST_END=12, PAREN_START=13, PAREN_END=14, COLON=15, IMPLY=16, SELECTOR=17, 
		RUN=18, IMPORT=19, FUNCTION=20, WHILE=21, IF=22, ELSE=23, END=24, SEP=25, 
		NOT=26, COMMENT=27, COMMANDS=28, INTEGER=29, INT_VALUE=30, FLOAT=31, STRING=32, 
		BOOL=33, NULL=34, NUMBER=35, WS=36, VARIABLE_IDENTIFIER=37, IDENTIFIER=38;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_ifBlock = 3, 
		RULE_elseIfBlock = 4, RULE_whileBlock = 5, RULE_functionBlock = 6, RULE_block = 7, 
		RULE_attrbinbuteAssign = 8, RULE_attributeJson = 9, RULE_import_ = 10, 
		RULE_assignment = 11, RULE_functionCall = 12, RULE_funcArgs = 13, RULE_expArgs = 14, 
		RULE_specifiedArgs = 15, RULE_specifiedArg = 16, RULE_command = 17, RULE_expression = 18, 
		RULE_constant = 19, RULE_assign = 20, RULE_scoreboardTarget = 21, RULE_implyTarget = 22, 
		RULE_commandExtend = 23, RULE_anonymousFunction = 24, RULE_list = 25, 
		RULE_listElems = 26, RULE_listElem = 27, RULE_obj = 28, RULE_pair = 29, 
		RULE_arr = 30, RULE_value = 31;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "ifBlock", "elseIfBlock", "whileBlock", 
			"functionBlock", "block", "attrbinbuteAssign", "attributeJson", "import_", 
			"assignment", "functionCall", "funcArgs", "expArgs", "specifiedArgs", 
			"specifiedArg", "command", "expression", "constant", "assign", "scoreboardTarget", 
			"implyTarget", "commandExtend", "anonymousFunction", "list", "listElems", 
			"listElem", "obj", "pair", "arr", "value"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, null, "'='", null, "'=>'", "'{'", "'}'", 
			"'['", "']'", "'('", "')'", "':'", "'::'", null, "'run'", "'import'", 
			"'function'", "'while'", "'if'", "'else'", "';'", "','", "'!'", null, 
			null, null, null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SIMPLE_ADDICTIVE", "MULTIPACATION", "ADDICTIVE", "COMPARATOR", 
			"COMPARASION", "ASSIGN", "ASSIGN_OPERATORS", "ARROW", "BLOCK_START", 
			"BLOCK_END", "LIST_START", "LIST_END", "PAREN_START", "PAREN_END", "COLON", 
			"IMPLY", "SELECTOR", "RUN", "IMPORT", "FUNCTION", "WHILE", "IF", "ELSE", 
			"END", "SEP", "NOT", "COMMENT", "COMMANDS", "INTEGER", "INT_VALUE", "FLOAT", 
			"STRING", "BOOL", "NULL", "NUMBER", "WS", "VARIABLE_IDENTIFIER", "IDENTIFIER"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "JMCParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public JMCParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(JMCParser.EOF, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(67);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 412727508992L) != 0)) {
				{
				{
				setState(64);
				line();
				}
				}
				setState(69);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(70);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LineContext extends ParserRuleContext {
		public IfBlockContext ifBlock() {
			return getRuleContext(IfBlockContext.class,0);
		}
		public WhileBlockContext whileBlock() {
			return getRuleContext(WhileBlockContext.class,0);
		}
		public FunctionBlockContext functionBlock() {
			return getRuleContext(FunctionBlockContext.class,0);
		}
		public Import_Context import_() {
			return getRuleContext(Import_Context.class,0);
		}
		public TerminalNode COMMENT() { return getToken(JMCParser.COMMENT, 0); }
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public LineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_line; }
	}

	public final LineContext line() throws RecognitionException {
		LineContext _localctx = new LineContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_line);
		try {
			setState(78);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				enterOuterAlt(_localctx, 1);
				{
				setState(72);
				ifBlock();
				}
				break;
			case WHILE:
				enterOuterAlt(_localctx, 2);
				{
				setState(73);
				whileBlock();
				}
				break;
			case FUNCTION:
				enterOuterAlt(_localctx, 3);
				{
				setState(74);
				functionBlock();
				}
				break;
			case IMPORT:
				enterOuterAlt(_localctx, 4);
				{
				setState(75);
				import_();
				}
				break;
			case COMMENT:
				enterOuterAlt(_localctx, 5);
				{
				setState(76);
				match(COMMENT);
				}
				break;
			case SELECTOR:
			case COMMANDS:
			case VARIABLE_IDENTIFIER:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 6);
				{
				setState(77);
				statement();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementContext extends ParserRuleContext {
		public TerminalNode END() { return getToken(JMCParser.END, 0); }
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public AttrbinbuteAssignContext attrbinbuteAssign() {
			return getRuleContext(AttrbinbuteAssignContext.class,0);
		}
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public CommandContext command() {
			return getRuleContext(CommandContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			setState(88);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SELECTOR:
			case VARIABLE_IDENTIFIER:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(83);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
				case 1:
					{
					setState(80);
					functionCall();
					}
					break;
				case 2:
					{
					setState(81);
					attrbinbuteAssign();
					}
					break;
				case 3:
					{
					setState(82);
					assignment();
					}
					break;
				}
				setState(85);
				match(END);
				}
				}
				break;
			case COMMANDS:
				enterOuterAlt(_localctx, 2);
				{
				setState(87);
				command();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IfBlockContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(JMCParser.IF, 0); }
		public TerminalNode PAREN_START() { return getToken(JMCParser.PAREN_START, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PAREN_END() { return getToken(JMCParser.PAREN_END, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public TerminalNode ELSE() { return getToken(JMCParser.ELSE, 0); }
		public ElseIfBlockContext elseIfBlock() {
			return getRuleContext(ElseIfBlockContext.class,0);
		}
		public IfBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifBlock; }
	}

	public final IfBlockContext ifBlock() throws RecognitionException {
		IfBlockContext _localctx = new IfBlockContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_ifBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(90);
			match(IF);
			setState(91);
			match(PAREN_START);
			setState(92);
			expression(0);
			setState(93);
			match(PAREN_END);
			setState(94);
			block();
			setState(97);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(95);
				match(ELSE);
				setState(96);
				elseIfBlock();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ElseIfBlockContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public IfBlockContext ifBlock() {
			return getRuleContext(IfBlockContext.class,0);
		}
		public ElseIfBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elseIfBlock; }
	}

	public final ElseIfBlockContext elseIfBlock() throws RecognitionException {
		ElseIfBlockContext _localctx = new ElseIfBlockContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_elseIfBlock);
		try {
			setState(101);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BLOCK_START:
				enterOuterAlt(_localctx, 1);
				{
				setState(99);
				block();
				}
				break;
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(100);
				ifBlock();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class WhileBlockContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(JMCParser.WHILE, 0); }
		public TerminalNode PAREN_START() { return getToken(JMCParser.PAREN_START, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PAREN_END() { return getToken(JMCParser.PAREN_END, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public WhileBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileBlock; }
	}

	public final WhileBlockContext whileBlock() throws RecognitionException {
		WhileBlockContext _localctx = new WhileBlockContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_whileBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(103);
			match(WHILE);
			setState(104);
			match(PAREN_START);
			setState(105);
			expression(0);
			setState(106);
			match(PAREN_END);
			setState(107);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionBlockContext extends ParserRuleContext {
		public TerminalNode FUNCTION() { return getToken(JMCParser.FUNCTION, 0); }
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public TerminalNode PAREN_START() { return getToken(JMCParser.PAREN_START, 0); }
		public TerminalNode PAREN_END() { return getToken(JMCParser.PAREN_END, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public FunctionBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionBlock; }
	}

	public final FunctionBlockContext functionBlock() throws RecognitionException {
		FunctionBlockContext _localctx = new FunctionBlockContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_functionBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			match(FUNCTION);
			setState(110);
			match(IDENTIFIER);
			setState(111);
			match(PAREN_START);
			setState(115);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 445133105152L) != 0)) {
				{
				{
				setState(112);
				expression(0);
				}
				}
				setState(117);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(118);
			match(PAREN_END);
			setState(119);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BlockContext extends ParserRuleContext {
		public TerminalNode BLOCK_START() { return getToken(JMCParser.BLOCK_START, 0); }
		public TerminalNode BLOCK_END() { return getToken(JMCParser.BLOCK_END, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(121);
			match(BLOCK_START);
			setState(125);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 412727508992L) != 0)) {
				{
				{
				setState(122);
				line();
				}
				}
				setState(127);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(128);
			match(BLOCK_END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AttrbinbuteAssignContext extends ParserRuleContext {
		public TerminalNode SELECTOR() { return getToken(JMCParser.SELECTOR, 0); }
		public TerminalNode IMPLY() { return getToken(JMCParser.IMPLY, 0); }
		public AssignContext assign() {
			return getRuleContext(AssignContext.class,0);
		}
		public AttributeJsonContext attributeJson() {
			return getRuleContext(AttributeJsonContext.class,0);
		}
		public AttrbinbuteAssignContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attrbinbuteAssign; }
	}

	public final AttrbinbuteAssignContext attrbinbuteAssign() throws RecognitionException {
		AttrbinbuteAssignContext _localctx = new AttrbinbuteAssignContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_attrbinbuteAssign);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			match(SELECTOR);
			setState(131);
			match(IMPLY);
			setState(132);
			assign();
			setState(133);
			attributeJson();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AttributeJsonContext extends ParserRuleContext {
		public ObjContext obj() {
			return getRuleContext(ObjContext.class,0);
		}
		public AttributeJsonContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attributeJson; }
	}

	public final AttributeJsonContext attributeJson() throws RecognitionException {
		AttributeJsonContext _localctx = new AttributeJsonContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_attributeJson);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			obj();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Import_Context extends ParserRuleContext {
		public TerminalNode IMPORT() { return getToken(JMCParser.IMPORT, 0); }
		public TerminalNode STRING() { return getToken(JMCParser.STRING, 0); }
		public TerminalNode END() { return getToken(JMCParser.END, 0); }
		public Import_Context(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_import_; }
	}

	public final Import_Context import_() throws RecognitionException {
		Import_Context _localctx = new Import_Context(_ctx, getState());
		enterRule(_localctx, 20, RULE_import_);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(137);
			match(IMPORT);
			setState(138);
			match(STRING);
			setState(139);
			match(END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode VARIABLE_IDENTIFIER() { return getToken(JMCParser.VARIABLE_IDENTIFIER, 0); }
		public ScoreboardTargetContext scoreboardTarget() {
			return getRuleContext(ScoreboardTargetContext.class,0);
		}
		public TerminalNode SIMPLE_ADDICTIVE() { return getToken(JMCParser.SIMPLE_ADDICTIVE, 0); }
		public AssignContext assign() {
			return getRuleContext(AssignContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(143);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case VARIABLE_IDENTIFIER:
				{
				setState(141);
				match(VARIABLE_IDENTIFIER);
				}
				break;
			case IDENTIFIER:
				{
				setState(142);
				scoreboardTarget();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(149);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SIMPLE_ADDICTIVE:
				{
				setState(145);
				match(SIMPLE_ADDICTIVE);
				}
				break;
			case COMPARATOR:
			case ASSIGN:
			case ASSIGN_OPERATORS:
				{
				{
				setState(146);
				assign();
				setState(147);
				expression(0);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionCallContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public TerminalNode PAREN_START() { return getToken(JMCParser.PAREN_START, 0); }
		public TerminalNode PAREN_END() { return getToken(JMCParser.PAREN_END, 0); }
		public FuncArgsContext funcArgs() {
			return getRuleContext(FuncArgsContext.class,0);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(151);
			match(IDENTIFIER);
			setState(152);
			match(PAREN_START);
			setState(154);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 445133105152L) != 0)) {
				{
				setState(153);
				funcArgs();
				}
			}

			setState(156);
			match(PAREN_END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FuncArgsContext extends ParserRuleContext {
		public ExpArgsContext expArgs() {
			return getRuleContext(ExpArgsContext.class,0);
		}
		public TerminalNode SEP() { return getToken(JMCParser.SEP, 0); }
		public SpecifiedArgsContext specifiedArgs() {
			return getRuleContext(SpecifiedArgsContext.class,0);
		}
		public FuncArgsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_funcArgs; }
	}

	public final FuncArgsContext funcArgs() throws RecognitionException {
		FuncArgsContext _localctx = new FuncArgsContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_funcArgs);
		int _la;
		try {
			setState(164);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(158);
				expArgs();
				setState(161);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==SEP) {
					{
					setState(159);
					match(SEP);
					setState(160);
					specifiedArgs();
					}
				}

				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(163);
				specifiedArgs();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpArgsContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> SEP() { return getTokens(JMCParser.SEP); }
		public TerminalNode SEP(int i) {
			return getToken(JMCParser.SEP, i);
		}
		public ExpArgsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expArgs; }
	}

	public final ExpArgsContext expArgs() throws RecognitionException {
		ExpArgsContext _localctx = new ExpArgsContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_expArgs);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			expression(0);
			setState(171);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(167);
					match(SEP);
					setState(168);
					expression(0);
					}
					} 
				}
				setState(173);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SpecifiedArgsContext extends ParserRuleContext {
		public List<SpecifiedArgContext> specifiedArg() {
			return getRuleContexts(SpecifiedArgContext.class);
		}
		public SpecifiedArgContext specifiedArg(int i) {
			return getRuleContext(SpecifiedArgContext.class,i);
		}
		public List<TerminalNode> SEP() { return getTokens(JMCParser.SEP); }
		public TerminalNode SEP(int i) {
			return getToken(JMCParser.SEP, i);
		}
		public SpecifiedArgsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_specifiedArgs; }
	}

	public final SpecifiedArgsContext specifiedArgs() throws RecognitionException {
		SpecifiedArgsContext _localctx = new SpecifiedArgsContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_specifiedArgs);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(174);
			specifiedArg();
			setState(179);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEP) {
				{
				{
				setState(175);
				match(SEP);
				setState(176);
				specifiedArg();
				}
				}
				setState(181);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SpecifiedArgContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public TerminalNode ASSIGN() { return getToken(JMCParser.ASSIGN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public SpecifiedArgContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_specifiedArg; }
	}

	public final SpecifiedArgContext specifiedArg() throws RecognitionException {
		SpecifiedArgContext _localctx = new SpecifiedArgContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_specifiedArg);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(182);
			match(IDENTIFIER);
			setState(183);
			match(ASSIGN);
			setState(184);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CommandContext extends ParserRuleContext {
		public TerminalNode COMMANDS() { return getToken(JMCParser.COMMANDS, 0); }
		public CommandExtendContext commandExtend() {
			return getRuleContext(CommandExtendContext.class,0);
		}
		public List<TerminalNode> END() { return getTokens(JMCParser.END); }
		public TerminalNode END(int i) {
			return getToken(JMCParser.END, i);
		}
		public List<TerminalNode> RUN() { return getTokens(JMCParser.RUN); }
		public TerminalNode RUN(int i) {
			return getToken(JMCParser.RUN, i);
		}
		public CommandContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_command; }
	}

	public final CommandContext command() throws RecognitionException {
		CommandContext _localctx = new CommandContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_command);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(186);
			match(COMMANDS);
			setState(188); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(187);
				_la = _input.LA(1);
				if ( _la <= 0 || (_la==RUN || _la==END) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				}
				setState(190); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 549738774526L) != 0) );
			}
			setState(194);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RUN:
				{
				setState(192);
				commandExtend();
				}
				break;
			case END:
				{
				setState(193);
				match(END);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ParentheziedExpressionContext extends ExpressionContext {
		public TerminalNode PAREN_START() { return getToken(JMCParser.PAREN_START, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PAREN_END() { return getToken(JMCParser.PAREN_END, 0); }
		public ParentheziedExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AnonymousFunctionExpressionContext extends ExpressionContext {
		public AnonymousFunctionContext anonymousFunction() {
			return getRuleContext(AnonymousFunctionContext.class,0);
		}
		public AnonymousFunctionExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class VariableIdentifierExpressionContext extends ExpressionContext {
		public TerminalNode VARIABLE_IDENTIFIER() { return getToken(JMCParser.VARIABLE_IDENTIFIER, 0); }
		public VariableIdentifierExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AdditiveExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode ADDICTIVE() { return getToken(JMCParser.ADDICTIVE, 0); }
		public AdditiveExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ComparisonExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode COMPARASION() { return getToken(JMCParser.COMPARASION, 0); }
		public ComparisonExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ConstantExpressionContext extends ExpressionContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public ConstantExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NotExpressionContext extends ExpressionContext {
		public TerminalNode NOT() { return getToken(JMCParser.NOT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NotExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ListExressionContext extends ExpressionContext {
		public ListContext list() {
			return getRuleContext(ListContext.class,0);
		}
		public ListExressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MultiplicativeExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode MULTIPACATION() { return getToken(JMCParser.MULTIPACATION, 0); }
		public MultiplicativeExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class FunctionCallExpressionContext extends ExpressionContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public FunctionCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	@SuppressWarnings("CheckReturnValue")
	public static class IdentifierExpressionContext extends ExpressionContext {
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public IdentifierExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 36;
		enterRecursionRule(_localctx, 36, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(209);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				_localctx = new ListExressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(197);
				list();
				}
				break;
			case 2:
				{
				_localctx = new AnonymousFunctionExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(198);
				anonymousFunction();
				}
				break;
			case 3:
				{
				_localctx = new ConstantExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(199);
				constant();
				}
				break;
			case 4:
				{
				_localctx = new VariableIdentifierExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(200);
				match(VARIABLE_IDENTIFIER);
				}
				break;
			case 5:
				{
				_localctx = new IdentifierExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(201);
				match(IDENTIFIER);
				}
				break;
			case 6:
				{
				_localctx = new FunctionCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(202);
				functionCall();
				}
				break;
			case 7:
				{
				_localctx = new ParentheziedExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(203);
				match(PAREN_START);
				setState(204);
				expression(0);
				setState(205);
				match(PAREN_END);
				}
				break;
			case 8:
				{
				_localctx = new NotExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(207);
				match(NOT);
				setState(208);
				expression(4);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(222);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(220);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(211);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(212);
						match(MULTIPACATION);
						setState(213);
						expression(4);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(214);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(215);
						match(ADDICTIVE);
						setState(216);
						expression(3);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(217);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(218);
						match(COMPARASION);
						setState(219);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(224);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(JMCParser.INTEGER, 0); }
		public TerminalNode FLOAT() { return getToken(JMCParser.FLOAT, 0); }
		public TerminalNode STRING() { return getToken(JMCParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(JMCParser.BOOL, 0); }
		public TerminalNode NULL() { return getToken(JMCParser.NULL, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(225);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 32749125632L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AssignContext extends ParserRuleContext {
		public TerminalNode ASSIGN_OPERATORS() { return getToken(JMCParser.ASSIGN_OPERATORS, 0); }
		public TerminalNode ASSIGN() { return getToken(JMCParser.ASSIGN, 0); }
		public TerminalNode COMPARATOR() { return getToken(JMCParser.COMPARATOR, 0); }
		public AssignContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assign; }
	}

	public final AssignContext assign() throws RecognitionException {
		AssignContext _localctx = new AssignContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_assign);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(227);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 208L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ScoreboardTargetContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public TerminalNode COLON() { return getToken(JMCParser.COLON, 0); }
		public TerminalNode SELECTOR() { return getToken(JMCParser.SELECTOR, 0); }
		public ScoreboardTargetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scoreboardTarget; }
	}

	public final ScoreboardTargetContext scoreboardTarget() throws RecognitionException {
		ScoreboardTargetContext _localctx = new ScoreboardTargetContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_scoreboardTarget);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(229);
			match(IDENTIFIER);
			setState(230);
			match(COLON);
			setState(231);
			match(SELECTOR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ImplyTargetContext extends ParserRuleContext {
		public TerminalNode SELECTOR() { return getToken(JMCParser.SELECTOR, 0); }
		public TerminalNode IMPLY() { return getToken(JMCParser.IMPLY, 0); }
		public ImplyTargetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_implyTarget; }
	}

	public final ImplyTargetContext implyTarget() throws RecognitionException {
		ImplyTargetContext _localctx = new ImplyTargetContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_implyTarget);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(233);
			match(SELECTOR);
			setState(234);
			match(IMPLY);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CommandExtendContext extends ParserRuleContext {
		public TerminalNode RUN() { return getToken(JMCParser.RUN, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public CommandContext command() {
			return getRuleContext(CommandContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public TerminalNode END() { return getToken(JMCParser.END, 0); }
		public CommandExtendContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_commandExtend; }
	}

	public final CommandExtendContext commandExtend() throws RecognitionException {
		CommandExtendContext _localctx = new CommandExtendContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_commandExtend);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(236);
			match(RUN);
			setState(242);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BLOCK_START:
				{
				setState(237);
				block();
				}
				break;
			case IDENTIFIER:
				{
				{
				setState(238);
				functionCall();
				setState(239);
				match(END);
				}
				}
				break;
			case COMMANDS:
				{
				setState(241);
				command();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AnonymousFunctionContext extends ParserRuleContext {
		public TerminalNode PAREN_START() { return getToken(JMCParser.PAREN_START, 0); }
		public TerminalNode PAREN_END() { return getToken(JMCParser.PAREN_END, 0); }
		public TerminalNode ARROW() { return getToken(JMCParser.ARROW, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public AnonymousFunctionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_anonymousFunction; }
	}

	public final AnonymousFunctionContext anonymousFunction() throws RecognitionException {
		AnonymousFunctionContext _localctx = new AnonymousFunctionContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_anonymousFunction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(244);
			match(PAREN_START);
			setState(245);
			match(PAREN_END);
			setState(246);
			match(ARROW);
			setState(247);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ListContext extends ParserRuleContext {
		public TerminalNode LIST_START() { return getToken(JMCParser.LIST_START, 0); }
		public TerminalNode LIST_END() { return getToken(JMCParser.LIST_END, 0); }
		public ListElemsContext listElems() {
			return getRuleContext(ListElemsContext.class,0);
		}
		public ListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_list; }
	}

	public final ListContext list() throws RecognitionException {
		ListContext _localctx = new ListContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(249);
			match(LIST_START);
			setState(251);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 307627034624L) != 0)) {
				{
				setState(250);
				listElems();
				}
			}

			setState(253);
			match(LIST_END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ListElemsContext extends ParserRuleContext {
		public List<ListElemContext> listElem() {
			return getRuleContexts(ListElemContext.class);
		}
		public ListElemContext listElem(int i) {
			return getRuleContext(ListElemContext.class,i);
		}
		public List<TerminalNode> SEP() { return getTokens(JMCParser.SEP); }
		public TerminalNode SEP(int i) {
			return getToken(JMCParser.SEP, i);
		}
		public ListElemsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_listElems; }
	}

	public final ListElemsContext listElems() throws RecognitionException {
		ListElemsContext _localctx = new ListElemsContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_listElems);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(255);
			listElem();
			setState(260);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEP) {
				{
				{
				setState(256);
				match(SEP);
				setState(257);
				listElem();
				}
				}
				setState(262);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ListElemContext extends ParserRuleContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public ListContext list() {
			return getRuleContext(ListContext.class,0);
		}
		public ListElemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_listElem; }
	}

	public final ListElemContext listElem() throws RecognitionException {
		ListElemContext _localctx = new ListElemContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_listElem);
		try {
			setState(266);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INTEGER:
			case FLOAT:
			case STRING:
			case BOOL:
			case NULL:
				enterOuterAlt(_localctx, 1);
				{
				setState(263);
				constant();
				}
				break;
			case IDENTIFIER:
				enterOuterAlt(_localctx, 2);
				{
				setState(264);
				match(IDENTIFIER);
				}
				break;
			case LIST_START:
				enterOuterAlt(_localctx, 3);
				{
				setState(265);
				list();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ObjContext extends ParserRuleContext {
		public TerminalNode BLOCK_START() { return getToken(JMCParser.BLOCK_START, 0); }
		public List<PairContext> pair() {
			return getRuleContexts(PairContext.class);
		}
		public PairContext pair(int i) {
			return getRuleContext(PairContext.class,i);
		}
		public TerminalNode BLOCK_END() { return getToken(JMCParser.BLOCK_END, 0); }
		public List<TerminalNode> SEP() { return getTokens(JMCParser.SEP); }
		public TerminalNode SEP(int i) {
			return getToken(JMCParser.SEP, i);
		}
		public ObjContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_obj; }
	}

	public final ObjContext obj() throws RecognitionException {
		ObjContext _localctx = new ObjContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_obj);
		int _la;
		try {
			setState(281);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(268);
				match(BLOCK_START);
				setState(269);
				pair();
				setState(274);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==SEP) {
					{
					{
					setState(270);
					match(SEP);
					setState(271);
					pair();
					}
					}
					setState(276);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(277);
				match(BLOCK_END);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(279);
				match(BLOCK_START);
				setState(280);
				match(BLOCK_END);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PairContext extends ParserRuleContext {
		public TerminalNode COLON() { return getToken(JMCParser.COLON, 0); }
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public TerminalNode COMMANDS() { return getToken(JMCParser.COMMANDS, 0); }
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public TerminalNode STRING() { return getToken(JMCParser.STRING, 0); }
		public PairContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pair; }
	}

	public final PairContext pair() throws RecognitionException {
		PairContext _localctx = new PairContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_pair);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(283);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 279441309696L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(284);
			match(COLON);
			setState(285);
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ArrContext extends ParserRuleContext {
		public TerminalNode LIST_START() { return getToken(JMCParser.LIST_START, 0); }
		public List<ValueContext> value() {
			return getRuleContexts(ValueContext.class);
		}
		public ValueContext value(int i) {
			return getRuleContext(ValueContext.class,i);
		}
		public TerminalNode LIST_END() { return getToken(JMCParser.LIST_END, 0); }
		public List<TerminalNode> SEP() { return getTokens(JMCParser.SEP); }
		public TerminalNode SEP(int i) {
			return getToken(JMCParser.SEP, i);
		}
		public ArrContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arr; }
	}

	public final ArrContext arr() throws RecognitionException {
		ArrContext _localctx = new ArrContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_arr);
		int _la;
		try {
			setState(300);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(287);
				match(LIST_START);
				setState(288);
				value();
				setState(293);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==SEP) {
					{
					{
					setState(289);
					match(SEP);
					setState(290);
					value();
					}
					}
					setState(295);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(296);
				match(LIST_END);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(298);
				match(LIST_START);
				setState(299);
				match(LIST_END);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ValueContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JMCParser.STRING, 0); }
		public TerminalNode INTEGER() { return getToken(JMCParser.INTEGER, 0); }
		public TerminalNode INT_VALUE() { return getToken(JMCParser.INT_VALUE, 0); }
		public ObjContext obj() {
			return getRuleContext(ObjContext.class,0);
		}
		public ArrContext arr() {
			return getRuleContext(ArrContext.class,0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_value);
		try {
			setState(307);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case STRING:
				enterOuterAlt(_localctx, 1);
				{
				setState(302);
				match(STRING);
				}
				break;
			case INTEGER:
				enterOuterAlt(_localctx, 2);
				{
				setState(303);
				match(INTEGER);
				}
				break;
			case INT_VALUE:
				enterOuterAlt(_localctx, 3);
				{
				setState(304);
				match(INT_VALUE);
				}
				break;
			case BLOCK_START:
				enterOuterAlt(_localctx, 4);
				{
				setState(305);
				obj();
				}
				break;
			case LIST_START:
				enterOuterAlt(_localctx, 5);
				{
				setState(306);
				arr();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 18:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 3);
		case 1:
			return precpred(_ctx, 2);
		case 2:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001&\u0136\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0001\u0000\u0005\u0000B\b\u0000\n\u0000\f\u0000"+
		"E\t\u0000\u0001\u0000\u0001\u0000\u0001\u0001\u0001\u0001\u0001\u0001"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0003\u0001O\b\u0001\u0001\u0002"+
		"\u0001\u0002\u0001\u0002\u0003\u0002T\b\u0002\u0001\u0002\u0001\u0002"+
		"\u0001\u0002\u0003\u0002Y\b\u0002\u0001\u0003\u0001\u0003\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003b\b\u0003"+
		"\u0001\u0004\u0001\u0004\u0003\u0004f\b\u0004\u0001\u0005\u0001\u0005"+
		"\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0001\u0006\u0005\u0006r\b\u0006\n\u0006\f\u0006u\t\u0006"+
		"\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0007\u0001\u0007\u0005\u0007"+
		"|\b\u0007\n\u0007\f\u0007\u007f\t\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\t\u0001\t\u0001\n\u0001\n\u0001"+
		"\n\u0001\n\u0001\u000b\u0001\u000b\u0003\u000b\u0090\b\u000b\u0001\u000b"+
		"\u0001\u000b\u0001\u000b\u0001\u000b\u0003\u000b\u0096\b\u000b\u0001\f"+
		"\u0001\f\u0001\f\u0003\f\u009b\b\f\u0001\f\u0001\f\u0001\r\u0001\r\u0001"+
		"\r\u0003\r\u00a2\b\r\u0001\r\u0003\r\u00a5\b\r\u0001\u000e\u0001\u000e"+
		"\u0001\u000e\u0005\u000e\u00aa\b\u000e\n\u000e\f\u000e\u00ad\t\u000e\u0001"+
		"\u000f\u0001\u000f\u0001\u000f\u0005\u000f\u00b2\b\u000f\n\u000f\f\u000f"+
		"\u00b5\t\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0011"+
		"\u0001\u0011\u0004\u0011\u00bd\b\u0011\u000b\u0011\f\u0011\u00be\u0001"+
		"\u0011\u0001\u0011\u0003\u0011\u00c3\b\u0011\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0003\u0012\u00d2"+
		"\b\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0005\u0012\u00dd\b\u0012\n"+
		"\u0012\f\u0012\u00e0\t\u0012\u0001\u0013\u0001\u0013\u0001\u0014\u0001"+
		"\u0014\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0016\u0001"+
		"\u0016\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001"+
		"\u0017\u0001\u0017\u0003\u0017\u00f3\b\u0017\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0019\u0001\u0019\u0003\u0019\u00fc"+
		"\b\u0019\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a\u0001\u001a\u0005"+
		"\u001a\u0103\b\u001a\n\u001a\f\u001a\u0106\t\u001a\u0001\u001b\u0001\u001b"+
		"\u0001\u001b\u0003\u001b\u010b\b\u001b\u0001\u001c\u0001\u001c\u0001\u001c"+
		"\u0001\u001c\u0005\u001c\u0111\b\u001c\n\u001c\f\u001c\u0114\t\u001c\u0001"+
		"\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0003\u001c\u011a\b\u001c\u0001"+
		"\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001e\u0001\u001e\u0001"+
		"\u001e\u0001\u001e\u0005\u001e\u0124\b\u001e\n\u001e\f\u001e\u0127\t\u001e"+
		"\u0001\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0003\u001e\u012d\b\u001e"+
		"\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0003\u001f"+
		"\u0134\b\u001f\u0001\u001f\u0000\u0001$ \u0000\u0002\u0004\u0006\b\n\f"+
		"\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e \"$&(*,.02468:"+
		"<>\u0000\u0004\u0002\u0000\u0012\u0012\u0018\u0018\u0002\u0000\u001d\u001d"+
		"\u001f\"\u0002\u0000\u0004\u0004\u0006\u0007\u0003\u0000\u001c\u001c "+
		" &&\u0143\u0000C\u0001\u0000\u0000\u0000\u0002N\u0001\u0000\u0000\u0000"+
		"\u0004X\u0001\u0000\u0000\u0000\u0006Z\u0001\u0000\u0000\u0000\be\u0001"+
		"\u0000\u0000\u0000\ng\u0001\u0000\u0000\u0000\fm\u0001\u0000\u0000\u0000"+
		"\u000ey\u0001\u0000\u0000\u0000\u0010\u0082\u0001\u0000\u0000\u0000\u0012"+
		"\u0087\u0001\u0000\u0000\u0000\u0014\u0089\u0001\u0000\u0000\u0000\u0016"+
		"\u008f\u0001\u0000\u0000\u0000\u0018\u0097\u0001\u0000\u0000\u0000\u001a"+
		"\u00a4\u0001\u0000\u0000\u0000\u001c\u00a6\u0001\u0000\u0000\u0000\u001e"+
		"\u00ae\u0001\u0000\u0000\u0000 \u00b6\u0001\u0000\u0000\u0000\"\u00ba"+
		"\u0001\u0000\u0000\u0000$\u00d1\u0001\u0000\u0000\u0000&\u00e1\u0001\u0000"+
		"\u0000\u0000(\u00e3\u0001\u0000\u0000\u0000*\u00e5\u0001\u0000\u0000\u0000"+
		",\u00e9\u0001\u0000\u0000\u0000.\u00ec\u0001\u0000\u0000\u00000\u00f4"+
		"\u0001\u0000\u0000\u00002\u00f9\u0001\u0000\u0000\u00004\u00ff\u0001\u0000"+
		"\u0000\u00006\u010a\u0001\u0000\u0000\u00008\u0119\u0001\u0000\u0000\u0000"+
		":\u011b\u0001\u0000\u0000\u0000<\u012c\u0001\u0000\u0000\u0000>\u0133"+
		"\u0001\u0000\u0000\u0000@B\u0003\u0002\u0001\u0000A@\u0001\u0000\u0000"+
		"\u0000BE\u0001\u0000\u0000\u0000CA\u0001\u0000\u0000\u0000CD\u0001\u0000"+
		"\u0000\u0000DF\u0001\u0000\u0000\u0000EC\u0001\u0000\u0000\u0000FG\u0005"+
		"\u0000\u0000\u0001G\u0001\u0001\u0000\u0000\u0000HO\u0003\u0006\u0003"+
		"\u0000IO\u0003\n\u0005\u0000JO\u0003\f\u0006\u0000KO\u0003\u0014\n\u0000"+
		"LO\u0005\u001b\u0000\u0000MO\u0003\u0004\u0002\u0000NH\u0001\u0000\u0000"+
		"\u0000NI\u0001\u0000\u0000\u0000NJ\u0001\u0000\u0000\u0000NK\u0001\u0000"+
		"\u0000\u0000NL\u0001\u0000\u0000\u0000NM\u0001\u0000\u0000\u0000O\u0003"+
		"\u0001\u0000\u0000\u0000PT\u0003\u0018\f\u0000QT\u0003\u0010\b\u0000R"+
		"T\u0003\u0016\u000b\u0000SP\u0001\u0000\u0000\u0000SQ\u0001\u0000\u0000"+
		"\u0000SR\u0001\u0000\u0000\u0000TU\u0001\u0000\u0000\u0000UV\u0005\u0018"+
		"\u0000\u0000VY\u0001\u0000\u0000\u0000WY\u0003\"\u0011\u0000XS\u0001\u0000"+
		"\u0000\u0000XW\u0001\u0000\u0000\u0000Y\u0005\u0001\u0000\u0000\u0000"+
		"Z[\u0005\u0016\u0000\u0000[\\\u0005\r\u0000\u0000\\]\u0003$\u0012\u0000"+
		"]^\u0005\u000e\u0000\u0000^a\u0003\u000e\u0007\u0000_`\u0005\u0017\u0000"+
		"\u0000`b\u0003\b\u0004\u0000a_\u0001\u0000\u0000\u0000ab\u0001\u0000\u0000"+
		"\u0000b\u0007\u0001\u0000\u0000\u0000cf\u0003\u000e\u0007\u0000df\u0003"+
		"\u0006\u0003\u0000ec\u0001\u0000\u0000\u0000ed\u0001\u0000\u0000\u0000"+
		"f\t\u0001\u0000\u0000\u0000gh\u0005\u0015\u0000\u0000hi\u0005\r\u0000"+
		"\u0000ij\u0003$\u0012\u0000jk\u0005\u000e\u0000\u0000kl\u0003\u000e\u0007"+
		"\u0000l\u000b\u0001\u0000\u0000\u0000mn\u0005\u0014\u0000\u0000no\u0005"+
		"&\u0000\u0000os\u0005\r\u0000\u0000pr\u0003$\u0012\u0000qp\u0001\u0000"+
		"\u0000\u0000ru\u0001\u0000\u0000\u0000sq\u0001\u0000\u0000\u0000st\u0001"+
		"\u0000\u0000\u0000tv\u0001\u0000\u0000\u0000us\u0001\u0000\u0000\u0000"+
		"vw\u0005\u000e\u0000\u0000wx\u0003\u000e\u0007\u0000x\r\u0001\u0000\u0000"+
		"\u0000y}\u0005\t\u0000\u0000z|\u0003\u0002\u0001\u0000{z\u0001\u0000\u0000"+
		"\u0000|\u007f\u0001\u0000\u0000\u0000}{\u0001\u0000\u0000\u0000}~\u0001"+
		"\u0000\u0000\u0000~\u0080\u0001\u0000\u0000\u0000\u007f}\u0001\u0000\u0000"+
		"\u0000\u0080\u0081\u0005\n\u0000\u0000\u0081\u000f\u0001\u0000\u0000\u0000"+
		"\u0082\u0083\u0005\u0011\u0000\u0000\u0083\u0084\u0005\u0010\u0000\u0000"+
		"\u0084\u0085\u0003(\u0014\u0000\u0085\u0086\u0003\u0012\t\u0000\u0086"+
		"\u0011\u0001\u0000\u0000\u0000\u0087\u0088\u00038\u001c\u0000\u0088\u0013"+
		"\u0001\u0000\u0000\u0000\u0089\u008a\u0005\u0013\u0000\u0000\u008a\u008b"+
		"\u0005 \u0000\u0000\u008b\u008c\u0005\u0018\u0000\u0000\u008c\u0015\u0001"+
		"\u0000\u0000\u0000\u008d\u0090\u0005%\u0000\u0000\u008e\u0090\u0003*\u0015"+
		"\u0000\u008f\u008d\u0001\u0000\u0000\u0000\u008f\u008e\u0001\u0000\u0000"+
		"\u0000\u0090\u0095\u0001\u0000\u0000\u0000\u0091\u0096\u0005\u0001\u0000"+
		"\u0000\u0092\u0093\u0003(\u0014\u0000\u0093\u0094\u0003$\u0012\u0000\u0094"+
		"\u0096\u0001\u0000\u0000\u0000\u0095\u0091\u0001\u0000\u0000\u0000\u0095"+
		"\u0092\u0001\u0000\u0000\u0000\u0096\u0017\u0001\u0000\u0000\u0000\u0097"+
		"\u0098\u0005&\u0000\u0000\u0098\u009a\u0005\r\u0000\u0000\u0099\u009b"+
		"\u0003\u001a\r\u0000\u009a\u0099\u0001\u0000\u0000\u0000\u009a\u009b\u0001"+
		"\u0000\u0000\u0000\u009b\u009c\u0001\u0000\u0000\u0000\u009c\u009d\u0005"+
		"\u000e\u0000\u0000\u009d\u0019\u0001\u0000\u0000\u0000\u009e\u00a1\u0003"+
		"\u001c\u000e\u0000\u009f\u00a0\u0005\u0019\u0000\u0000\u00a0\u00a2\u0003"+
		"\u001e\u000f\u0000\u00a1\u009f\u0001\u0000\u0000\u0000\u00a1\u00a2\u0001"+
		"\u0000\u0000\u0000\u00a2\u00a5\u0001\u0000\u0000\u0000\u00a3\u00a5\u0003"+
		"\u001e\u000f\u0000\u00a4\u009e\u0001\u0000\u0000\u0000\u00a4\u00a3\u0001"+
		"\u0000\u0000\u0000\u00a5\u001b\u0001\u0000\u0000\u0000\u00a6\u00ab\u0003"+
		"$\u0012\u0000\u00a7\u00a8\u0005\u0019\u0000\u0000\u00a8\u00aa\u0003$\u0012"+
		"\u0000\u00a9\u00a7\u0001\u0000\u0000\u0000\u00aa\u00ad\u0001\u0000\u0000"+
		"\u0000\u00ab\u00a9\u0001\u0000\u0000\u0000\u00ab\u00ac\u0001\u0000\u0000"+
		"\u0000\u00ac\u001d\u0001\u0000\u0000\u0000\u00ad\u00ab\u0001\u0000\u0000"+
		"\u0000\u00ae\u00b3\u0003 \u0010\u0000\u00af\u00b0\u0005\u0019\u0000\u0000"+
		"\u00b0\u00b2\u0003 \u0010\u0000\u00b1\u00af\u0001\u0000\u0000\u0000\u00b2"+
		"\u00b5\u0001\u0000\u0000\u0000\u00b3\u00b1\u0001\u0000\u0000\u0000\u00b3"+
		"\u00b4\u0001\u0000\u0000\u0000\u00b4\u001f\u0001\u0000\u0000\u0000\u00b5"+
		"\u00b3\u0001\u0000\u0000\u0000\u00b6\u00b7\u0005&\u0000\u0000\u00b7\u00b8"+
		"\u0005\u0006\u0000\u0000\u00b8\u00b9\u0003$\u0012\u0000\u00b9!\u0001\u0000"+
		"\u0000\u0000\u00ba\u00bc\u0005\u001c\u0000\u0000\u00bb\u00bd\b\u0000\u0000"+
		"\u0000\u00bc\u00bb\u0001\u0000\u0000\u0000\u00bd\u00be\u0001\u0000\u0000"+
		"\u0000\u00be\u00bc\u0001\u0000\u0000\u0000\u00be\u00bf\u0001\u0000\u0000"+
		"\u0000\u00bf\u00c2\u0001\u0000\u0000\u0000\u00c0\u00c3\u0003.\u0017\u0000"+
		"\u00c1\u00c3\u0005\u0018\u0000\u0000\u00c2\u00c0\u0001\u0000\u0000\u0000"+
		"\u00c2\u00c1\u0001\u0000\u0000\u0000\u00c3#\u0001\u0000\u0000\u0000\u00c4"+
		"\u00c5\u0006\u0012\uffff\uffff\u0000\u00c5\u00d2\u00032\u0019\u0000\u00c6"+
		"\u00d2\u00030\u0018\u0000\u00c7\u00d2\u0003&\u0013\u0000\u00c8\u00d2\u0005"+
		"%\u0000\u0000\u00c9\u00d2\u0005&\u0000\u0000\u00ca\u00d2\u0003\u0018\f"+
		"\u0000\u00cb\u00cc\u0005\r\u0000\u0000\u00cc\u00cd\u0003$\u0012\u0000"+
		"\u00cd\u00ce\u0005\u000e\u0000\u0000\u00ce\u00d2\u0001\u0000\u0000\u0000"+
		"\u00cf\u00d0\u0005\u001a\u0000\u0000\u00d0\u00d2\u0003$\u0012\u0004\u00d1"+
		"\u00c4\u0001\u0000\u0000\u0000\u00d1\u00c6\u0001\u0000\u0000\u0000\u00d1"+
		"\u00c7\u0001\u0000\u0000\u0000\u00d1\u00c8\u0001\u0000\u0000\u0000\u00d1"+
		"\u00c9\u0001\u0000\u0000\u0000\u00d1\u00ca\u0001\u0000\u0000\u0000\u00d1"+
		"\u00cb\u0001\u0000\u0000\u0000\u00d1\u00cf\u0001\u0000\u0000\u0000\u00d2"+
		"\u00de\u0001\u0000\u0000\u0000\u00d3\u00d4\n\u0003\u0000\u0000\u00d4\u00d5"+
		"\u0005\u0002\u0000\u0000\u00d5\u00dd\u0003$\u0012\u0004\u00d6\u00d7\n"+
		"\u0002\u0000\u0000\u00d7\u00d8\u0005\u0003\u0000\u0000\u00d8\u00dd\u0003"+
		"$\u0012\u0003\u00d9\u00da\n\u0001\u0000\u0000\u00da\u00db\u0005\u0005"+
		"\u0000\u0000\u00db\u00dd\u0003$\u0012\u0002\u00dc\u00d3\u0001\u0000\u0000"+
		"\u0000\u00dc\u00d6\u0001\u0000\u0000\u0000\u00dc\u00d9\u0001\u0000\u0000"+
		"\u0000\u00dd\u00e0\u0001\u0000\u0000\u0000\u00de\u00dc\u0001\u0000\u0000"+
		"\u0000\u00de\u00df\u0001\u0000\u0000\u0000\u00df%\u0001\u0000\u0000\u0000"+
		"\u00e0\u00de\u0001\u0000\u0000\u0000\u00e1\u00e2\u0007\u0001\u0000\u0000"+
		"\u00e2\'\u0001\u0000\u0000\u0000\u00e3\u00e4\u0007\u0002\u0000\u0000\u00e4"+
		")\u0001\u0000\u0000\u0000\u00e5\u00e6\u0005&\u0000\u0000\u00e6\u00e7\u0005"+
		"\u000f\u0000\u0000\u00e7\u00e8\u0005\u0011\u0000\u0000\u00e8+\u0001\u0000"+
		"\u0000\u0000\u00e9\u00ea\u0005\u0011\u0000\u0000\u00ea\u00eb\u0005\u0010"+
		"\u0000\u0000\u00eb-\u0001\u0000\u0000\u0000\u00ec\u00f2\u0005\u0012\u0000"+
		"\u0000\u00ed\u00f3\u0003\u000e\u0007\u0000\u00ee\u00ef\u0003\u0018\f\u0000"+
		"\u00ef\u00f0\u0005\u0018\u0000\u0000\u00f0\u00f3\u0001\u0000\u0000\u0000"+
		"\u00f1\u00f3\u0003\"\u0011\u0000\u00f2\u00ed\u0001\u0000\u0000\u0000\u00f2"+
		"\u00ee\u0001\u0000\u0000\u0000\u00f2\u00f1\u0001\u0000\u0000\u0000\u00f3"+
		"/\u0001\u0000\u0000\u0000\u00f4\u00f5\u0005\r\u0000\u0000\u00f5\u00f6"+
		"\u0005\u000e\u0000\u0000\u00f6\u00f7\u0005\b\u0000\u0000\u00f7\u00f8\u0003"+
		"\u000e\u0007\u0000\u00f81\u0001\u0000\u0000\u0000\u00f9\u00fb\u0005\u000b"+
		"\u0000\u0000\u00fa\u00fc\u00034\u001a\u0000\u00fb\u00fa\u0001\u0000\u0000"+
		"\u0000\u00fb\u00fc\u0001\u0000\u0000\u0000\u00fc\u00fd\u0001\u0000\u0000"+
		"\u0000\u00fd\u00fe\u0005\f\u0000\u0000\u00fe3\u0001\u0000\u0000\u0000"+
		"\u00ff\u0104\u00036\u001b\u0000\u0100\u0101\u0005\u0019\u0000\u0000\u0101"+
		"\u0103\u00036\u001b\u0000\u0102\u0100\u0001\u0000\u0000\u0000\u0103\u0106"+
		"\u0001\u0000\u0000\u0000\u0104\u0102\u0001\u0000\u0000\u0000\u0104\u0105"+
		"\u0001\u0000\u0000\u0000\u01055\u0001\u0000\u0000\u0000\u0106\u0104\u0001"+
		"\u0000\u0000\u0000\u0107\u010b\u0003&\u0013\u0000\u0108\u010b\u0005&\u0000"+
		"\u0000\u0109\u010b\u00032\u0019\u0000\u010a\u0107\u0001\u0000\u0000\u0000"+
		"\u010a\u0108\u0001\u0000\u0000\u0000\u010a\u0109\u0001\u0000\u0000\u0000"+
		"\u010b7\u0001\u0000\u0000\u0000\u010c\u010d\u0005\t\u0000\u0000\u010d"+
		"\u0112\u0003:\u001d\u0000\u010e\u010f\u0005\u0019\u0000\u0000\u010f\u0111"+
		"\u0003:\u001d\u0000\u0110\u010e\u0001\u0000\u0000\u0000\u0111\u0114\u0001"+
		"\u0000\u0000\u0000\u0112\u0110\u0001\u0000\u0000\u0000\u0112\u0113\u0001"+
		"\u0000\u0000\u0000\u0113\u0115\u0001\u0000\u0000\u0000\u0114\u0112\u0001"+
		"\u0000\u0000\u0000\u0115\u0116\u0005\n\u0000\u0000\u0116\u011a\u0001\u0000"+
		"\u0000\u0000\u0117\u0118\u0005\t\u0000\u0000\u0118\u011a\u0005\n\u0000"+
		"\u0000\u0119\u010c\u0001\u0000\u0000\u0000\u0119\u0117\u0001\u0000\u0000"+
		"\u0000\u011a9\u0001\u0000\u0000\u0000\u011b\u011c\u0007\u0003\u0000\u0000"+
		"\u011c\u011d\u0005\u000f\u0000\u0000\u011d\u011e\u0003>\u001f\u0000\u011e"+
		";\u0001\u0000\u0000\u0000\u011f\u0120\u0005\u000b\u0000\u0000\u0120\u0125"+
		"\u0003>\u001f\u0000\u0121\u0122\u0005\u0019\u0000\u0000\u0122\u0124\u0003"+
		">\u001f\u0000\u0123\u0121\u0001\u0000\u0000\u0000\u0124\u0127\u0001\u0000"+
		"\u0000\u0000\u0125\u0123\u0001\u0000\u0000\u0000\u0125\u0126\u0001\u0000"+
		"\u0000\u0000\u0126\u0128\u0001\u0000\u0000\u0000\u0127\u0125\u0001\u0000"+
		"\u0000\u0000\u0128\u0129\u0005\f\u0000\u0000\u0129\u012d\u0001\u0000\u0000"+
		"\u0000\u012a\u012b\u0005\u000b\u0000\u0000\u012b\u012d\u0005\f\u0000\u0000"+
		"\u012c\u011f\u0001\u0000\u0000\u0000\u012c\u012a\u0001\u0000\u0000\u0000"+
		"\u012d=\u0001\u0000\u0000\u0000\u012e\u0134\u0005 \u0000\u0000\u012f\u0134"+
		"\u0005\u001d\u0000\u0000\u0130\u0134\u0005\u001e\u0000\u0000\u0131\u0134"+
		"\u00038\u001c\u0000\u0132\u0134\u0003<\u001e\u0000\u0133\u012e\u0001\u0000"+
		"\u0000\u0000\u0133\u012f\u0001\u0000\u0000\u0000\u0133\u0130\u0001\u0000"+
		"\u0000\u0000\u0133\u0131\u0001\u0000\u0000\u0000\u0133\u0132\u0001\u0000"+
		"\u0000\u0000\u0134?\u0001\u0000\u0000\u0000\u001dCNSXaes}\u008f\u0095"+
		"\u009a\u00a1\u00a4\u00ab\u00b3\u00be\u00c2\u00d1\u00dc\u00de\u00f2\u00fb"+
		"\u0104\u010a\u0112\u0119\u0125\u012c\u0133";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}