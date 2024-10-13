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
		RUN=18, IMPORT=19, FUNCTION=20, WHILE=21, IF=22, ELSE=23, NEW=24, END=25, 
		SEP=26, NOT=27, COMMENT=28, COMMANDS=29, JSON_INT=30, INTEGER=31, FLOAT=32, 
		STRING=33, BOOL=34, NULL=35, NUMBER=36, WS=37, VARIABLE_IDENTIFIER=38, 
		IDENTIFIER=39;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_ifBlock = 3, 
		RULE_elseIfBlock = 4, RULE_whileBlock = 5, RULE_functionBlock = 6, RULE_block = 7, 
		RULE_attrbinbuteAssign = 8, RULE_attributeJson = 9, RULE_import_ = 10, 
		RULE_assignment = 11, RULE_functionCall = 12, RULE_funcArgs = 13, RULE_expArgs = 14, 
		RULE_expArg = 15, RULE_specifiedArgs = 16, RULE_specifiedArg = 17, RULE_command = 18, 
		RULE_newJsonFile = 19, RULE_expression = 20, RULE_hardCodeArg = 21, RULE_constant = 22, 
		RULE_assign = 23, RULE_scoreboardTarget = 24, RULE_implyTarget = 25, RULE_commandExtend = 26, 
		RULE_anonymousFunction = 27, RULE_list = 28, RULE_listElems = 29, RULE_listElem = 30, 
		RULE_jsonObj = 31, RULE_jsonObjPairs = 32, RULE_jsonPair = 33, RULE_jsonList = 34, 
		RULE_jsonElems = 35, RULE_jsonValue = 36;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "ifBlock", "elseIfBlock", "whileBlock", 
			"functionBlock", "block", "attrbinbuteAssign", "attributeJson", "import_", 
			"assignment", "functionCall", "funcArgs", "expArgs", "expArg", "specifiedArgs", 
			"specifiedArg", "command", "newJsonFile", "expression", "hardCodeArg", 
			"constant", "assign", "scoreboardTarget", "implyTarget", "commandExtend", 
			"anonymousFunction", "list", "listElems", "listElem", "jsonObj", "jsonObjPairs", 
			"jsonPair", "jsonList", "jsonElems", "jsonValue"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, null, "'='", null, "'=>'", "'{'", "'}'", 
			"'['", "']'", "'('", "')'", "':'", "'::'", null, "'run'", "'import'", 
			"'function'", "'while'", "'if'", "'else'", "'new'", "';'", "','", "'!'", 
			null, null, null, null, null, null, null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SIMPLE_ADDICTIVE", "MULTIPACATION", "ADDICTIVE", "COMPARATOR", 
			"COMPARASION", "ASSIGN", "ASSIGN_OPERATORS", "ARROW", "BLOCK_START", 
			"BLOCK_END", "LIST_START", "LIST_END", "PAREN_START", "PAREN_END", "COLON", 
			"IMPLY", "SELECTOR", "RUN", "IMPORT", "FUNCTION", "WHILE", "IF", "ELSE", 
			"NEW", "END", "SEP", "NOT", "COMMENT", "COMMANDS", "JSON_INT", "INTEGER", 
			"FLOAT", "STRING", "BOOL", "NULL", "NUMBER", "WS", "VARIABLE_IDENTIFIER", 
			"IDENTIFIER"
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


	    private bool IsFuncNameHardcode() {
	        return ((FunctionCallContext)getInvokingContext(12)).funcName is "Hardcode.repeat" or "Hardcode.repeatList";
	    }

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
			setState(77);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 825463799808L) != 0)) {
				{
				{
				setState(74);
				line();
				}
				}
				setState(79);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(80);
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
		public NewJsonFileContext newJsonFile() {
			return getRuleContext(NewJsonFileContext.class,0);
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
			setState(89);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				enterOuterAlt(_localctx, 1);
				{
				setState(82);
				ifBlock();
				}
				break;
			case WHILE:
				enterOuterAlt(_localctx, 2);
				{
				setState(83);
				whileBlock();
				}
				break;
			case FUNCTION:
				enterOuterAlt(_localctx, 3);
				{
				setState(84);
				functionBlock();
				}
				break;
			case IMPORT:
				enterOuterAlt(_localctx, 4);
				{
				setState(85);
				import_();
				}
				break;
			case COMMENT:
				enterOuterAlt(_localctx, 5);
				{
				setState(86);
				match(COMMENT);
				}
				break;
			case SELECTOR:
			case COMMANDS:
			case VARIABLE_IDENTIFIER:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 6);
				{
				setState(87);
				statement();
				}
				break;
			case NEW:
				enterOuterAlt(_localctx, 7);
				{
				setState(88);
				newJsonFile();
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
			setState(99);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SELECTOR:
			case VARIABLE_IDENTIFIER:
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(94);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
				case 1:
					{
					setState(91);
					functionCall();
					}
					break;
				case 2:
					{
					setState(92);
					attrbinbuteAssign();
					}
					break;
				case 3:
					{
					setState(93);
					assignment();
					}
					break;
				}
				setState(96);
				match(END);
				}
				}
				break;
			case COMMANDS:
				enterOuterAlt(_localctx, 2);
				{
				setState(98);
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
			setState(101);
			match(IF);
			setState(102);
			match(PAREN_START);
			setState(103);
			expression(0);
			setState(104);
			match(PAREN_END);
			setState(105);
			block();
			setState(108);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(106);
				match(ELSE);
				setState(107);
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
			setState(112);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BLOCK_START:
				enterOuterAlt(_localctx, 1);
				{
				setState(110);
				block();
				}
				break;
			case IF:
				enterOuterAlt(_localctx, 2);
				{
				setState(111);
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
			setState(114);
			match(WHILE);
			setState(115);
			match(PAREN_START);
			setState(116);
			expression(0);
			setState(117);
			match(PAREN_END);
			setState(118);
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
			setState(120);
			match(FUNCTION);
			setState(121);
			match(IDENTIFIER);
			setState(122);
			match(PAREN_START);
			setState(126);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 891339941888L) != 0)) {
				{
				{
				setState(123);
				expression(0);
				}
				}
				setState(128);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(129);
			match(PAREN_END);
			setState(130);
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
			setState(132);
			match(BLOCK_START);
			setState(136);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 825463799808L) != 0)) {
				{
				{
				setState(133);
				line();
				}
				}
				setState(138);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(139);
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
			setState(141);
			match(SELECTOR);
			setState(142);
			match(IMPLY);
			setState(143);
			assign();
			setState(144);
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
		public JsonObjContext jsonObj() {
			return getRuleContext(JsonObjContext.class,0);
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
			setState(146);
			jsonObj();
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
			setState(148);
			match(IMPORT);
			setState(149);
			match(STRING);
			setState(150);
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
			setState(154);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case VARIABLE_IDENTIFIER:
				{
				setState(152);
				match(VARIABLE_IDENTIFIER);
				}
				break;
			case IDENTIFIER:
				{
				setState(153);
				scoreboardTarget();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(160);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SIMPLE_ADDICTIVE:
				{
				setState(156);
				match(SIMPLE_ADDICTIVE);
				}
				break;
			case COMPARATOR:
			case ASSIGN:
			case ASSIGN_OPERATORS:
				{
				{
				setState(157);
				assign();
				setState(158);
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
		public string funcName = "";
		public string arg = "";
		public Token IDENTIFIER;
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
			setState(162);
			((FunctionCallContext)_localctx).IDENTIFIER = match(IDENTIFIER);

			    ((FunctionCallContext)getInvokingContext(12)).funcName =  (((FunctionCallContext)_localctx).IDENTIFIER!=null?((FunctionCallContext)_localctx).IDENTIFIER.getText():null);

			setState(164);
			match(PAREN_START);
			setState(166);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 891339941888L) != 0)) {
				{
				setState(165);
				funcArgs();
				}
			}

			setState(168);
			match(PAREN_END);

			    ((FunctionCallContext)getInvokingContext(12)).funcName =  "";

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
		public SpecifiedArgsContext specifiedArgs() {
			return getRuleContext(SpecifiedArgsContext.class,0);
		}
		public ExpArgsContext expArgs() {
			return getRuleContext(ExpArgsContext.class,0);
		}
		public TerminalNode SEP() { return getToken(JMCParser.SEP, 0); }
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
			enterOuterAlt(_localctx, 1);
			{
			setState(177);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				{
				{
				setState(171);
				expArgs();
				setState(174);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==SEP) {
					{
					setState(172);
					match(SEP);
					setState(173);
					specifiedArgs();
					}
				}

				}
				}
				break;
			case 2:
				{
				setState(176);
				specifiedArgs();
				}
				break;
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
	public static class ExpArgsContext extends ParserRuleContext {
		public ExpArgContext arg1;
		public List<ExpArgContext> expArg() {
			return getRuleContexts(ExpArgContext.class);
		}
		public ExpArgContext expArg(int i) {
			return getRuleContext(ExpArgContext.class,i);
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
			setState(179);
			((ExpArgsContext)_localctx).arg1 = expArg();
			 
			    if (((FunctionCallContext)getInvokingContext(12)).funcName is "Hardcode.repeat" or "Hardcode.repeatList") {
			        ((FunctionCallContext)getInvokingContext(12)).arg =  (((ExpArgsContext)_localctx).arg1!=null?_input.getText(((ExpArgsContext)_localctx).arg1.start,((ExpArgsContext)_localctx).arg1.stop):null)[1..^1];
			    }

			setState(185);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(181);
					match(SEP);
					setState(182);
					expArg();
					}
					} 
				}
				setState(187);
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
	public static class ExpArgContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ExpArgContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expArg; }
	}

	public final ExpArgContext expArg() throws RecognitionException {
		ExpArgContext _localctx = new ExpArgContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_expArg);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(188);
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
		enterRule(_localctx, 32, RULE_specifiedArgs);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(190);
			specifiedArg();
			setState(195);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEP) {
				{
				{
				setState(191);
				match(SEP);
				setState(192);
				specifiedArg();
				}
				}
				setState(197);
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
		enterRule(_localctx, 34, RULE_specifiedArg);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(198);
			match(IDENTIFIER);
			setState(199);
			match(ASSIGN);
			setState(200);
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
		enterRule(_localctx, 36, RULE_command);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(202);
			match(COMMANDS);
			setState(204); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(203);
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
				setState(206); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 1099477811198L) != 0) );
			}
			setState(210);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RUN:
				{
				setState(208);
				commandExtend();
				}
				break;
			case END:
				{
				setState(209);
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
	public static class NewJsonFileContext extends ParserRuleContext {
		public TerminalNode NEW() { return getToken(JMCParser.NEW, 0); }
		public TerminalNode PAREN_START() { return getToken(JMCParser.PAREN_START, 0); }
		public List<TerminalNode> IDENTIFIER() { return getTokens(JMCParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(JMCParser.IDENTIFIER, i);
		}
		public TerminalNode PAREN_END() { return getToken(JMCParser.PAREN_END, 0); }
		public TerminalNode COMMANDS() { return getToken(JMCParser.COMMANDS, 0); }
		public JsonObjContext jsonObj() {
			return getRuleContext(JsonObjContext.class,0);
		}
		public JsonListContext jsonList() {
			return getRuleContext(JsonListContext.class,0);
		}
		public NewJsonFileContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_newJsonFile; }
	}

	public final NewJsonFileContext newJsonFile() throws RecognitionException {
		NewJsonFileContext _localctx = new NewJsonFileContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_newJsonFile);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(212);
			match(NEW);
			setState(213);
			_la = _input.LA(1);
			if ( !(_la==COMMANDS || _la==IDENTIFIER) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(214);
			match(PAREN_START);
			setState(215);
			match(IDENTIFIER);
			setState(216);
			match(PAREN_END);
			setState(219);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BLOCK_START:
				{
				setState(217);
				jsonObj();
				}
				break;
			case LIST_START:
				{
				setState(218);
				jsonList();
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
		int _startState = 40;
		enterRecursionRule(_localctx, 40, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(234);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				{
				_localctx = new ListExressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(222);
				list();
				}
				break;
			case 2:
				{
				_localctx = new AnonymousFunctionExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(223);
				anonymousFunction();
				}
				break;
			case 3:
				{
				_localctx = new ConstantExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(224);
				constant();
				}
				break;
			case 4:
				{
				_localctx = new VariableIdentifierExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(225);
				match(VARIABLE_IDENTIFIER);
				}
				break;
			case 5:
				{
				_localctx = new IdentifierExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(226);
				match(IDENTIFIER);
				}
				break;
			case 6:
				{
				_localctx = new FunctionCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(227);
				functionCall();
				}
				break;
			case 7:
				{
				_localctx = new ParentheziedExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(228);
				match(PAREN_START);
				setState(229);
				expression(0);
				setState(230);
				match(PAREN_END);
				}
				break;
			case 8:
				{
				_localctx = new NotExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(232);
				match(NOT);
				setState(233);
				expression(4);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(247);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(245);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(236);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(237);
						match(MULTIPACATION);
						setState(238);
						expression(4);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(239);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(240);
						match(ADDICTIVE);
						setState(241);
						expression(3);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(242);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(243);
						match(COMPARASION);
						setState(244);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(249);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
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
	public static class HardCodeArgContext extends ParserRuleContext {
		public HardCodeArgContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_hardCodeArg; }
	}

	public final HardCodeArgContext hardCodeArg() throws RecognitionException {
		HardCodeArgContext _localctx = new HardCodeArgContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_hardCodeArg);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(250);
			if (!(IsArg(((FunctionCallContext)getInvokingContext(12)).arg))) throw new FailedPredicateException(this, "IsArg($functionCall::arg)");
			setState(251);
			matchWildcard();
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
		enterRule(_localctx, 44, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(253);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 66571993088L) != 0)) ) {
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
		enterRule(_localctx, 46, RULE_assign);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(255);
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
		enterRule(_localctx, 48, RULE_scoreboardTarget);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(257);
			match(IDENTIFIER);
			setState(258);
			match(COLON);
			setState(259);
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
		enterRule(_localctx, 50, RULE_implyTarget);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(261);
			match(SELECTOR);
			setState(262);
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
		enterRule(_localctx, 52, RULE_commandExtend);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(264);
			match(RUN);
			setState(270);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BLOCK_START:
				{
				setState(265);
				block();
				}
				break;
			case IDENTIFIER:
				{
				{
				setState(266);
				functionCall();
				setState(267);
				match(END);
				}
				}
				break;
			case COMMANDS:
				{
				setState(269);
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
		enterRule(_localctx, 54, RULE_anonymousFunction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(272);
			match(PAREN_START);
			setState(273);
			match(PAREN_END);
			setState(274);
			match(ARROW);
			setState(275);
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
		enterRule(_localctx, 56, RULE_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(277);
			match(LIST_START);
			setState(279);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 616327809024L) != 0)) {
				{
				setState(278);
				listElems();
				}
			}

			setState(281);
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
		enterRule(_localctx, 58, RULE_listElems);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(283);
			listElem();
			setState(288);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEP) {
				{
				{
				setState(284);
				match(SEP);
				setState(285);
				listElem();
				}
				}
				setState(290);
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
		enterRule(_localctx, 60, RULE_listElem);
		try {
			setState(294);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INTEGER:
			case FLOAT:
			case STRING:
			case BOOL:
			case NULL:
				enterOuterAlt(_localctx, 1);
				{
				setState(291);
				constant();
				}
				break;
			case IDENTIFIER:
				enterOuterAlt(_localctx, 2);
				{
				setState(292);
				match(IDENTIFIER);
				}
				break;
			case LIST_START:
				enterOuterAlt(_localctx, 3);
				{
				setState(293);
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
	public static class JsonObjContext extends ParserRuleContext {
		public TerminalNode BLOCK_START() { return getToken(JMCParser.BLOCK_START, 0); }
		public TerminalNode BLOCK_END() { return getToken(JMCParser.BLOCK_END, 0); }
		public JsonObjPairsContext jsonObjPairs() {
			return getRuleContext(JsonObjPairsContext.class,0);
		}
		public JsonObjContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonObj; }
	}

	public final JsonObjContext jsonObj() throws RecognitionException {
		JsonObjContext _localctx = new JsonObjContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_jsonObj);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(296);
			match(BLOCK_START);
			setState(298);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 558882619392L) != 0)) {
				{
				setState(297);
				jsonObjPairs();
				}
			}

			setState(300);
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
	public static class JsonObjPairsContext extends ParserRuleContext {
		public List<JsonPairContext> jsonPair() {
			return getRuleContexts(JsonPairContext.class);
		}
		public JsonPairContext jsonPair(int i) {
			return getRuleContext(JsonPairContext.class,i);
		}
		public List<TerminalNode> SEP() { return getTokens(JMCParser.SEP); }
		public TerminalNode SEP(int i) {
			return getToken(JMCParser.SEP, i);
		}
		public JsonObjPairsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonObjPairs; }
	}

	public final JsonObjPairsContext jsonObjPairs() throws RecognitionException {
		JsonObjPairsContext _localctx = new JsonObjPairsContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_jsonObjPairs);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(302);
			jsonPair();
			setState(307);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEP) {
				{
				{
				setState(303);
				match(SEP);
				setState(304);
				jsonPair();
				}
				}
				setState(309);
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
	public static class JsonPairContext extends ParserRuleContext {
		public TerminalNode COLON() { return getToken(JMCParser.COLON, 0); }
		public JsonValueContext jsonValue() {
			return getRuleContext(JsonValueContext.class,0);
		}
		public TerminalNode COMMANDS() { return getToken(JMCParser.COMMANDS, 0); }
		public TerminalNode IDENTIFIER() { return getToken(JMCParser.IDENTIFIER, 0); }
		public TerminalNode STRING() { return getToken(JMCParser.STRING, 0); }
		public JsonPairContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonPair; }
	}

	public final JsonPairContext jsonPair() throws RecognitionException {
		JsonPairContext _localctx = new JsonPairContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_jsonPair);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(310);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 558882619392L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(311);
			match(COLON);
			setState(312);
			jsonValue();
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
	public static class JsonListContext extends ParserRuleContext {
		public TerminalNode LIST_START() { return getToken(JMCParser.LIST_START, 0); }
		public TerminalNode LIST_END() { return getToken(JMCParser.LIST_END, 0); }
		public JsonElemsContext jsonElems() {
			return getRuleContext(JsonElemsContext.class,0);
		}
		public JsonListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonList; }
	}

	public final JsonListContext jsonList() throws RecognitionException {
		JsonListContext _localctx = new JsonListContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_jsonList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(314);
			match(LIST_START);
			setState(316);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 26843548160L) != 0)) {
				{
				setState(315);
				jsonElems();
				}
			}

			setState(318);
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
	public static class JsonElemsContext extends ParserRuleContext {
		public List<JsonValueContext> jsonValue() {
			return getRuleContexts(JsonValueContext.class);
		}
		public JsonValueContext jsonValue(int i) {
			return getRuleContext(JsonValueContext.class,i);
		}
		public List<TerminalNode> SEP() { return getTokens(JMCParser.SEP); }
		public TerminalNode SEP(int i) {
			return getToken(JMCParser.SEP, i);
		}
		public JsonElemsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonElems; }
	}

	public final JsonElemsContext jsonElems() throws RecognitionException {
		JsonElemsContext _localctx = new JsonElemsContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_jsonElems);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(320);
			jsonValue();
			setState(325);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEP) {
				{
				{
				setState(321);
				match(SEP);
				setState(322);
				jsonValue();
				}
				}
				setState(327);
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
	public static class JsonValueContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JMCParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(JMCParser.BOOL, 0); }
		public TerminalNode JSON_INT() { return getToken(JMCParser.JSON_INT, 0); }
		public JsonObjContext jsonObj() {
			return getRuleContext(JsonObjContext.class,0);
		}
		public JsonListContext jsonList() {
			return getRuleContext(JsonListContext.class,0);
		}
		public JsonValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValue; }
	}

	public final JsonValueContext jsonValue() throws RecognitionException {
		JsonValueContext _localctx = new JsonValueContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_jsonValue);
		try {
			setState(333);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case STRING:
				enterOuterAlt(_localctx, 1);
				{
				setState(328);
				match(STRING);
				}
				break;
			case BOOL:
				enterOuterAlt(_localctx, 2);
				{
				setState(329);
				match(BOOL);
				}
				break;
			case JSON_INT:
				enterOuterAlt(_localctx, 3);
				{
				setState(330);
				match(JSON_INT);
				}
				break;
			case BLOCK_START:
				enterOuterAlt(_localctx, 4);
				{
				setState(331);
				jsonObj();
				}
				break;
			case LIST_START:
				enterOuterAlt(_localctx, 5);
				{
				setState(332);
				jsonList();
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
		case 20:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		case 21:
			return hardCodeArg_sempred((HardCodeArgContext)_localctx, predIndex);
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
	private boolean hardCodeArg_sempred(HardCodeArgContext _localctx, int predIndex) {
		switch (predIndex) {
		case 3:
			return IsArg(((FunctionCallContext)getInvokingContext(12)).arg);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001\'\u0150\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0002 \u0007 \u0002!\u0007!\u0002\"\u0007\"\u0002"+
		"#\u0007#\u0002$\u0007$\u0001\u0000\u0005\u0000L\b\u0000\n\u0000\f\u0000"+
		"O\t\u0000\u0001\u0000\u0001\u0000\u0001\u0001\u0001\u0001\u0001\u0001"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0003\u0001Z\b\u0001"+
		"\u0001\u0002\u0001\u0002\u0001\u0002\u0003\u0002_\b\u0002\u0001\u0002"+
		"\u0001\u0002\u0001\u0002\u0003\u0002d\b\u0002\u0001\u0003\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003"+
		"m\b\u0003\u0001\u0004\u0001\u0004\u0003\u0004q\b\u0004\u0001\u0005\u0001"+
		"\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0001"+
		"\u0006\u0001\u0006\u0001\u0006\u0005\u0006}\b\u0006\n\u0006\f\u0006\u0080"+
		"\t\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0007\u0001\u0007\u0005"+
		"\u0007\u0087\b\u0007\n\u0007\f\u0007\u008a\t\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\t\u0001\t\u0001\n\u0001"+
		"\n\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0003\u000b\u009b\b\u000b\u0001"+
		"\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0003\u000b\u00a1\b\u000b\u0001"+
		"\f\u0001\f\u0001\f\u0001\f\u0003\f\u00a7\b\f\u0001\f\u0001\f\u0001\f\u0001"+
		"\r\u0001\r\u0001\r\u0003\r\u00af\b\r\u0001\r\u0003\r\u00b2\b\r\u0001\u000e"+
		"\u0001\u000e\u0001\u000e\u0001\u000e\u0005\u000e\u00b8\b\u000e\n\u000e"+
		"\f\u000e\u00bb\t\u000e\u0001\u000f\u0001\u000f\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0005\u0010\u00c2\b\u0010\n\u0010\f\u0010\u00c5\t\u0010\u0001"+
		"\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0004"+
		"\u0012\u00cd\b\u0012\u000b\u0012\f\u0012\u00ce\u0001\u0012\u0001\u0012"+
		"\u0003\u0012\u00d3\b\u0012\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013"+
		"\u0001\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u00dc\b\u0013\u0001\u0014"+
		"\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014"+
		"\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014"+
		"\u0003\u0014\u00eb\b\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014"+
		"\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0005\u0014"+
		"\u00f6\b\u0014\n\u0014\f\u0014\u00f9\t\u0014\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0016\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0001"+
		"\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0003"+
		"\u001a\u010f\b\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001"+
		"\u001b\u0001\u001c\u0001\u001c\u0003\u001c\u0118\b\u001c\u0001\u001c\u0001"+
		"\u001c\u0001\u001d\u0001\u001d\u0001\u001d\u0005\u001d\u011f\b\u001d\n"+
		"\u001d\f\u001d\u0122\t\u001d\u0001\u001e\u0001\u001e\u0001\u001e\u0003"+
		"\u001e\u0127\b\u001e\u0001\u001f\u0001\u001f\u0003\u001f\u012b\b\u001f"+
		"\u0001\u001f\u0001\u001f\u0001 \u0001 \u0001 \u0005 \u0132\b \n \f \u0135"+
		"\t \u0001!\u0001!\u0001!\u0001!\u0001\"\u0001\"\u0003\"\u013d\b\"\u0001"+
		"\"\u0001\"\u0001#\u0001#\u0001#\u0005#\u0144\b#\n#\f#\u0147\t#\u0001$"+
		"\u0001$\u0001$\u0001$\u0001$\u0003$\u014e\b$\u0001$\u0000\u0001(%\u0000"+
		"\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c"+
		"\u001e \"$&(*,.02468:<>@BDFH\u0000\u0005\u0002\u0000\u0012\u0012\u0019"+
		"\u0019\u0002\u0000\u001d\u001d\'\'\u0001\u0000\u001f#\u0002\u0000\u0004"+
		"\u0004\u0006\u0007\u0003\u0000\u001d\u001d!!\'\'\u015a\u0000M\u0001\u0000"+
		"\u0000\u0000\u0002Y\u0001\u0000\u0000\u0000\u0004c\u0001\u0000\u0000\u0000"+
		"\u0006e\u0001\u0000\u0000\u0000\bp\u0001\u0000\u0000\u0000\nr\u0001\u0000"+
		"\u0000\u0000\fx\u0001\u0000\u0000\u0000\u000e\u0084\u0001\u0000\u0000"+
		"\u0000\u0010\u008d\u0001\u0000\u0000\u0000\u0012\u0092\u0001\u0000\u0000"+
		"\u0000\u0014\u0094\u0001\u0000\u0000\u0000\u0016\u009a\u0001\u0000\u0000"+
		"\u0000\u0018\u00a2\u0001\u0000\u0000\u0000\u001a\u00b1\u0001\u0000\u0000"+
		"\u0000\u001c\u00b3\u0001\u0000\u0000\u0000\u001e\u00bc\u0001\u0000\u0000"+
		"\u0000 \u00be\u0001\u0000\u0000\u0000\"\u00c6\u0001\u0000\u0000\u0000"+
		"$\u00ca\u0001\u0000\u0000\u0000&\u00d4\u0001\u0000\u0000\u0000(\u00ea"+
		"\u0001\u0000\u0000\u0000*\u00fa\u0001\u0000\u0000\u0000,\u00fd\u0001\u0000"+
		"\u0000\u0000.\u00ff\u0001\u0000\u0000\u00000\u0101\u0001\u0000\u0000\u0000"+
		"2\u0105\u0001\u0000\u0000\u00004\u0108\u0001\u0000\u0000\u00006\u0110"+
		"\u0001\u0000\u0000\u00008\u0115\u0001\u0000\u0000\u0000:\u011b\u0001\u0000"+
		"\u0000\u0000<\u0126\u0001\u0000\u0000\u0000>\u0128\u0001\u0000\u0000\u0000"+
		"@\u012e\u0001\u0000\u0000\u0000B\u0136\u0001\u0000\u0000\u0000D\u013a"+
		"\u0001\u0000\u0000\u0000F\u0140\u0001\u0000\u0000\u0000H\u014d\u0001\u0000"+
		"\u0000\u0000JL\u0003\u0002\u0001\u0000KJ\u0001\u0000\u0000\u0000LO\u0001"+
		"\u0000\u0000\u0000MK\u0001\u0000\u0000\u0000MN\u0001\u0000\u0000\u0000"+
		"NP\u0001\u0000\u0000\u0000OM\u0001\u0000\u0000\u0000PQ\u0005\u0000\u0000"+
		"\u0001Q\u0001\u0001\u0000\u0000\u0000RZ\u0003\u0006\u0003\u0000SZ\u0003"+
		"\n\u0005\u0000TZ\u0003\f\u0006\u0000UZ\u0003\u0014\n\u0000VZ\u0005\u001c"+
		"\u0000\u0000WZ\u0003\u0004\u0002\u0000XZ\u0003&\u0013\u0000YR\u0001\u0000"+
		"\u0000\u0000YS\u0001\u0000\u0000\u0000YT\u0001\u0000\u0000\u0000YU\u0001"+
		"\u0000\u0000\u0000YV\u0001\u0000\u0000\u0000YW\u0001\u0000\u0000\u0000"+
		"YX\u0001\u0000\u0000\u0000Z\u0003\u0001\u0000\u0000\u0000[_\u0003\u0018"+
		"\f\u0000\\_\u0003\u0010\b\u0000]_\u0003\u0016\u000b\u0000^[\u0001\u0000"+
		"\u0000\u0000^\\\u0001\u0000\u0000\u0000^]\u0001\u0000\u0000\u0000_`\u0001"+
		"\u0000\u0000\u0000`a\u0005\u0019\u0000\u0000ad\u0001\u0000\u0000\u0000"+
		"bd\u0003$\u0012\u0000c^\u0001\u0000\u0000\u0000cb\u0001\u0000\u0000\u0000"+
		"d\u0005\u0001\u0000\u0000\u0000ef\u0005\u0016\u0000\u0000fg\u0005\r\u0000"+
		"\u0000gh\u0003(\u0014\u0000hi\u0005\u000e\u0000\u0000il\u0003\u000e\u0007"+
		"\u0000jk\u0005\u0017\u0000\u0000km\u0003\b\u0004\u0000lj\u0001\u0000\u0000"+
		"\u0000lm\u0001\u0000\u0000\u0000m\u0007\u0001\u0000\u0000\u0000nq\u0003"+
		"\u000e\u0007\u0000oq\u0003\u0006\u0003\u0000pn\u0001\u0000\u0000\u0000"+
		"po\u0001\u0000\u0000\u0000q\t\u0001\u0000\u0000\u0000rs\u0005\u0015\u0000"+
		"\u0000st\u0005\r\u0000\u0000tu\u0003(\u0014\u0000uv\u0005\u000e\u0000"+
		"\u0000vw\u0003\u000e\u0007\u0000w\u000b\u0001\u0000\u0000\u0000xy\u0005"+
		"\u0014\u0000\u0000yz\u0005\'\u0000\u0000z~\u0005\r\u0000\u0000{}\u0003"+
		"(\u0014\u0000|{\u0001\u0000\u0000\u0000}\u0080\u0001\u0000\u0000\u0000"+
		"~|\u0001\u0000\u0000\u0000~\u007f\u0001\u0000\u0000\u0000\u007f\u0081"+
		"\u0001\u0000\u0000\u0000\u0080~\u0001\u0000\u0000\u0000\u0081\u0082\u0005"+
		"\u000e\u0000\u0000\u0082\u0083\u0003\u000e\u0007\u0000\u0083\r\u0001\u0000"+
		"\u0000\u0000\u0084\u0088\u0005\t\u0000\u0000\u0085\u0087\u0003\u0002\u0001"+
		"\u0000\u0086\u0085\u0001\u0000\u0000\u0000\u0087\u008a\u0001\u0000\u0000"+
		"\u0000\u0088\u0086\u0001\u0000\u0000\u0000\u0088\u0089\u0001\u0000\u0000"+
		"\u0000\u0089\u008b\u0001\u0000\u0000\u0000\u008a\u0088\u0001\u0000\u0000"+
		"\u0000\u008b\u008c\u0005\n\u0000\u0000\u008c\u000f\u0001\u0000\u0000\u0000"+
		"\u008d\u008e\u0005\u0011\u0000\u0000\u008e\u008f\u0005\u0010\u0000\u0000"+
		"\u008f\u0090\u0003.\u0017\u0000\u0090\u0091\u0003\u0012\t\u0000\u0091"+
		"\u0011\u0001\u0000\u0000\u0000\u0092\u0093\u0003>\u001f\u0000\u0093\u0013"+
		"\u0001\u0000\u0000\u0000\u0094\u0095\u0005\u0013\u0000\u0000\u0095\u0096"+
		"\u0005!\u0000\u0000\u0096\u0097\u0005\u0019\u0000\u0000\u0097\u0015\u0001"+
		"\u0000\u0000\u0000\u0098\u009b\u0005&\u0000\u0000\u0099\u009b\u00030\u0018"+
		"\u0000\u009a\u0098\u0001\u0000\u0000\u0000\u009a\u0099\u0001\u0000\u0000"+
		"\u0000\u009b\u00a0\u0001\u0000\u0000\u0000\u009c\u00a1\u0005\u0001\u0000"+
		"\u0000\u009d\u009e\u0003.\u0017\u0000\u009e\u009f\u0003(\u0014\u0000\u009f"+
		"\u00a1\u0001\u0000\u0000\u0000\u00a0\u009c\u0001\u0000\u0000\u0000\u00a0"+
		"\u009d\u0001\u0000\u0000\u0000\u00a1\u0017\u0001\u0000\u0000\u0000\u00a2"+
		"\u00a3\u0005\'\u0000\u0000\u00a3\u00a4\u0006\f\uffff\uffff\u0000\u00a4"+
		"\u00a6\u0005\r\u0000\u0000\u00a5\u00a7\u0003\u001a\r\u0000\u00a6\u00a5"+
		"\u0001\u0000\u0000\u0000\u00a6\u00a7\u0001\u0000\u0000\u0000\u00a7\u00a8"+
		"\u0001\u0000\u0000\u0000\u00a8\u00a9\u0005\u000e\u0000\u0000\u00a9\u00aa"+
		"\u0006\f\uffff\uffff\u0000\u00aa\u0019\u0001\u0000\u0000\u0000\u00ab\u00ae"+
		"\u0003\u001c\u000e\u0000\u00ac\u00ad\u0005\u001a\u0000\u0000\u00ad\u00af"+
		"\u0003 \u0010\u0000\u00ae\u00ac\u0001\u0000\u0000\u0000\u00ae\u00af\u0001"+
		"\u0000\u0000\u0000\u00af\u00b2\u0001\u0000\u0000\u0000\u00b0\u00b2\u0003"+
		" \u0010\u0000\u00b1\u00ab\u0001\u0000\u0000\u0000\u00b1\u00b0\u0001\u0000"+
		"\u0000\u0000\u00b2\u001b\u0001\u0000\u0000\u0000\u00b3\u00b4\u0003\u001e"+
		"\u000f\u0000\u00b4\u00b9\u0006\u000e\uffff\uffff\u0000\u00b5\u00b6\u0005"+
		"\u001a\u0000\u0000\u00b6\u00b8\u0003\u001e\u000f\u0000\u00b7\u00b5\u0001"+
		"\u0000\u0000\u0000\u00b8\u00bb\u0001\u0000\u0000\u0000\u00b9\u00b7\u0001"+
		"\u0000\u0000\u0000\u00b9\u00ba\u0001\u0000\u0000\u0000\u00ba\u001d\u0001"+
		"\u0000\u0000\u0000\u00bb\u00b9\u0001\u0000\u0000\u0000\u00bc\u00bd\u0003"+
		"(\u0014\u0000\u00bd\u001f\u0001\u0000\u0000\u0000\u00be\u00c3\u0003\""+
		"\u0011\u0000\u00bf\u00c0\u0005\u001a\u0000\u0000\u00c0\u00c2\u0003\"\u0011"+
		"\u0000\u00c1\u00bf\u0001\u0000\u0000\u0000\u00c2\u00c5\u0001\u0000\u0000"+
		"\u0000\u00c3\u00c1\u0001\u0000\u0000\u0000\u00c3\u00c4\u0001\u0000\u0000"+
		"\u0000\u00c4!\u0001\u0000\u0000\u0000\u00c5\u00c3\u0001\u0000\u0000\u0000"+
		"\u00c6\u00c7\u0005\'\u0000\u0000\u00c7\u00c8\u0005\u0006\u0000\u0000\u00c8"+
		"\u00c9\u0003(\u0014\u0000\u00c9#\u0001\u0000\u0000\u0000\u00ca\u00cc\u0005"+
		"\u001d\u0000\u0000\u00cb\u00cd\b\u0000\u0000\u0000\u00cc\u00cb\u0001\u0000"+
		"\u0000\u0000\u00cd\u00ce\u0001\u0000\u0000\u0000\u00ce\u00cc\u0001\u0000"+
		"\u0000\u0000\u00ce\u00cf\u0001\u0000\u0000\u0000\u00cf\u00d2\u0001\u0000"+
		"\u0000\u0000\u00d0\u00d3\u00034\u001a\u0000\u00d1\u00d3\u0005\u0019\u0000"+
		"\u0000\u00d2\u00d0\u0001\u0000\u0000\u0000\u00d2\u00d1\u0001\u0000\u0000"+
		"\u0000\u00d3%\u0001\u0000\u0000\u0000\u00d4\u00d5\u0005\u0018\u0000\u0000"+
		"\u00d5\u00d6\u0007\u0001\u0000\u0000\u00d6\u00d7\u0005\r\u0000\u0000\u00d7"+
		"\u00d8\u0005\'\u0000\u0000\u00d8\u00db\u0005\u000e\u0000\u0000\u00d9\u00dc"+
		"\u0003>\u001f\u0000\u00da\u00dc\u0003D\"\u0000\u00db\u00d9\u0001\u0000"+
		"\u0000\u0000\u00db\u00da\u0001\u0000\u0000\u0000\u00dc\'\u0001\u0000\u0000"+
		"\u0000\u00dd\u00de\u0006\u0014\uffff\uffff\u0000\u00de\u00eb\u00038\u001c"+
		"\u0000\u00df\u00eb\u00036\u001b\u0000\u00e0\u00eb\u0003,\u0016\u0000\u00e1"+
		"\u00eb\u0005&\u0000\u0000\u00e2\u00eb\u0005\'\u0000\u0000\u00e3\u00eb"+
		"\u0003\u0018\f\u0000\u00e4\u00e5\u0005\r\u0000\u0000\u00e5\u00e6\u0003"+
		"(\u0014\u0000\u00e6\u00e7\u0005\u000e\u0000\u0000\u00e7\u00eb\u0001\u0000"+
		"\u0000\u0000\u00e8\u00e9\u0005\u001b\u0000\u0000\u00e9\u00eb\u0003(\u0014"+
		"\u0004\u00ea\u00dd\u0001\u0000\u0000\u0000\u00ea\u00df\u0001\u0000\u0000"+
		"\u0000\u00ea\u00e0\u0001\u0000\u0000\u0000\u00ea\u00e1\u0001\u0000\u0000"+
		"\u0000\u00ea\u00e2\u0001\u0000\u0000\u0000\u00ea\u00e3\u0001\u0000\u0000"+
		"\u0000\u00ea\u00e4\u0001\u0000\u0000\u0000\u00ea\u00e8\u0001\u0000\u0000"+
		"\u0000\u00eb\u00f7\u0001\u0000\u0000\u0000\u00ec\u00ed\n\u0003\u0000\u0000"+
		"\u00ed\u00ee\u0005\u0002\u0000\u0000\u00ee\u00f6\u0003(\u0014\u0004\u00ef"+
		"\u00f0\n\u0002\u0000\u0000\u00f0\u00f1\u0005\u0003\u0000\u0000\u00f1\u00f6"+
		"\u0003(\u0014\u0003\u00f2\u00f3\n\u0001\u0000\u0000\u00f3\u00f4\u0005"+
		"\u0005\u0000\u0000\u00f4\u00f6\u0003(\u0014\u0002\u00f5\u00ec\u0001\u0000"+
		"\u0000\u0000\u00f5\u00ef\u0001\u0000\u0000\u0000\u00f5\u00f2\u0001\u0000"+
		"\u0000\u0000\u00f6\u00f9\u0001\u0000\u0000\u0000\u00f7\u00f5\u0001\u0000"+
		"\u0000\u0000\u00f7\u00f8\u0001\u0000\u0000\u0000\u00f8)\u0001\u0000\u0000"+
		"\u0000\u00f9\u00f7\u0001\u0000\u0000\u0000\u00fa\u00fb\u0004\u0015\u0003"+
		"\u0001\u00fb\u00fc\t\u0000\u0000\u0000\u00fc+\u0001\u0000\u0000\u0000"+
		"\u00fd\u00fe\u0007\u0002\u0000\u0000\u00fe-\u0001\u0000\u0000\u0000\u00ff"+
		"\u0100\u0007\u0003\u0000\u0000\u0100/\u0001\u0000\u0000\u0000\u0101\u0102"+
		"\u0005\'\u0000\u0000\u0102\u0103\u0005\u000f\u0000\u0000\u0103\u0104\u0005"+
		"\u0011\u0000\u0000\u01041\u0001\u0000\u0000\u0000\u0105\u0106\u0005\u0011"+
		"\u0000\u0000\u0106\u0107\u0005\u0010\u0000\u0000\u01073\u0001\u0000\u0000"+
		"\u0000\u0108\u010e\u0005\u0012\u0000\u0000\u0109\u010f\u0003\u000e\u0007"+
		"\u0000\u010a\u010b\u0003\u0018\f\u0000\u010b\u010c\u0005\u0019\u0000\u0000"+
		"\u010c\u010f\u0001\u0000\u0000\u0000\u010d\u010f\u0003$\u0012\u0000\u010e"+
		"\u0109\u0001\u0000\u0000\u0000\u010e\u010a\u0001\u0000\u0000\u0000\u010e"+
		"\u010d\u0001\u0000\u0000\u0000\u010f5\u0001\u0000\u0000\u0000\u0110\u0111"+
		"\u0005\r\u0000\u0000\u0111\u0112\u0005\u000e\u0000\u0000\u0112\u0113\u0005"+
		"\b\u0000\u0000\u0113\u0114\u0003\u000e\u0007\u0000\u01147\u0001\u0000"+
		"\u0000\u0000\u0115\u0117\u0005\u000b\u0000\u0000\u0116\u0118\u0003:\u001d"+
		"\u0000\u0117\u0116\u0001\u0000\u0000\u0000\u0117\u0118\u0001\u0000\u0000"+
		"\u0000\u0118\u0119\u0001\u0000\u0000\u0000\u0119\u011a\u0005\f\u0000\u0000"+
		"\u011a9\u0001\u0000\u0000\u0000\u011b\u0120\u0003<\u001e\u0000\u011c\u011d"+
		"\u0005\u001a\u0000\u0000\u011d\u011f\u0003<\u001e\u0000\u011e\u011c\u0001"+
		"\u0000\u0000\u0000\u011f\u0122\u0001\u0000\u0000\u0000\u0120\u011e\u0001"+
		"\u0000\u0000\u0000\u0120\u0121\u0001\u0000\u0000\u0000\u0121;\u0001\u0000"+
		"\u0000\u0000\u0122\u0120\u0001\u0000\u0000\u0000\u0123\u0127\u0003,\u0016"+
		"\u0000\u0124\u0127\u0005\'\u0000\u0000\u0125\u0127\u00038\u001c\u0000"+
		"\u0126\u0123\u0001\u0000\u0000\u0000\u0126\u0124\u0001\u0000\u0000\u0000"+
		"\u0126\u0125\u0001\u0000\u0000\u0000\u0127=\u0001\u0000\u0000\u0000\u0128"+
		"\u012a\u0005\t\u0000\u0000\u0129\u012b\u0003@ \u0000\u012a\u0129\u0001"+
		"\u0000\u0000\u0000\u012a\u012b\u0001\u0000\u0000\u0000\u012b\u012c\u0001"+
		"\u0000\u0000\u0000\u012c\u012d\u0005\n\u0000\u0000\u012d?\u0001\u0000"+
		"\u0000\u0000\u012e\u0133\u0003B!\u0000\u012f\u0130\u0005\u001a\u0000\u0000"+
		"\u0130\u0132\u0003B!\u0000\u0131\u012f\u0001\u0000\u0000\u0000\u0132\u0135"+
		"\u0001\u0000\u0000\u0000\u0133\u0131\u0001\u0000\u0000\u0000\u0133\u0134"+
		"\u0001\u0000\u0000\u0000\u0134A\u0001\u0000\u0000\u0000\u0135\u0133\u0001"+
		"\u0000\u0000\u0000\u0136\u0137\u0007\u0004\u0000\u0000\u0137\u0138\u0005"+
		"\u000f\u0000\u0000\u0138\u0139\u0003H$\u0000\u0139C\u0001\u0000\u0000"+
		"\u0000\u013a\u013c\u0005\u000b\u0000\u0000\u013b\u013d\u0003F#\u0000\u013c"+
		"\u013b\u0001\u0000\u0000\u0000\u013c\u013d\u0001\u0000\u0000\u0000\u013d"+
		"\u013e\u0001\u0000\u0000\u0000\u013e\u013f\u0005\f\u0000\u0000\u013fE"+
		"\u0001\u0000\u0000\u0000\u0140\u0145\u0003H$\u0000\u0141\u0142\u0005\u001a"+
		"\u0000\u0000\u0142\u0144\u0003H$\u0000\u0143\u0141\u0001\u0000\u0000\u0000"+
		"\u0144\u0147\u0001\u0000\u0000\u0000\u0145\u0143\u0001\u0000\u0000\u0000"+
		"\u0145\u0146\u0001\u0000\u0000\u0000\u0146G\u0001\u0000\u0000\u0000\u0147"+
		"\u0145\u0001\u0000\u0000\u0000\u0148\u014e\u0005!\u0000\u0000\u0149\u014e"+
		"\u0005\"\u0000\u0000\u014a\u014e\u0005\u001e\u0000\u0000\u014b\u014e\u0003"+
		">\u001f\u0000\u014c\u014e\u0003D\"\u0000\u014d\u0148\u0001\u0000\u0000"+
		"\u0000\u014d\u0149\u0001\u0000\u0000\u0000\u014d\u014a\u0001\u0000\u0000"+
		"\u0000\u014d\u014b\u0001\u0000\u0000\u0000\u014d\u014c\u0001\u0000\u0000"+
		"\u0000\u014eI\u0001\u0000\u0000\u0000\u001eMY^clp~\u0088\u009a\u00a0\u00a6"+
		"\u00ae\u00b1\u00b9\u00c3\u00ce\u00d2\u00db\u00ea\u00f5\u00f7\u010e\u0117"+
		"\u0120\u0126\u012a\u0133\u013c\u0145\u014d";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}