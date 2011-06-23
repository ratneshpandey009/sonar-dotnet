/*
 * Copyright (C) 2010 SonarSource SA
 * All rights reserved
 * mailto:contact AT sonarsource DOT com
 */
package com.sonar.csharp.squid.metric;

import org.sonar.plugins.csharp.api.squid.CSharpMetric;

import com.sonar.csharp.squid.api.CSharpGrammar;
import com.sonar.csharp.squid.api.ast.CSharpAstVisitor;
import com.sonar.sslr.api.AstNode;

/**
 * Visitor that computes the number of accessors.
 */
public class CSharpAccessorVisitor extends CSharpAstVisitor {

  /**
   * {@inheritDoc}
   */
  @Override
  public void init() {
    CSharpGrammar g = getCSharpGrammar();
    subscribeTo(g.getAccessorDeclaration, g.setAccessorDeclaration, g.addAccessorDeclaration, g.removeAccessorDeclaration);
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public void visitNode(AstNode node) {
    peekSourceCode().add(CSharpMetric.ACCESSORS, 1);
  }

}
